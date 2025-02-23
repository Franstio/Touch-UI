﻿using Dapper;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestTCP1.Lib.DbUtil;
using TestTCP1.Model;
using TestTCP1.Model.ViewModel;

namespace TestTCP1.Lib
{
    public class DbConn : DrawMarkPointUtil,IMarkPointDb
    {
        public string ConnString { get;  private set; } = string.Empty;
        public DbConn()
        {
            SqlMapper.Settings.CommandTimeout = 60;
            ConnString = ConfigurationManager.AppSettings["ConnString"] ?? ""; 
        }
        public DbConn(string conn)
        {
            SqlMapper.Settings.CommandTimeout = 60;
            ConnString = conn;//ConfigurationManager.AppSettings["ConnString"] ?? "";
        }
        public SqlConnection GetConn()
        {
            return new SqlConnection(ConnString);
        }
        public async Task SavePosition(PosView data)
        {
            using (var conn = GetConn())
            {
                await conn.OpenAsync();
                string query = "Select d.Model,Position as Pos,d.X,d.Y,d.Z,d.CameraCheckPoint,c.CameraPoint From Tbl_Data d left join tbl_campoint c on d.model=c.model Where d.Model=@Model and d.Position=@Position;";
                var find = await conn.QueryAsync<PosView>(query,new {Model=data.Model,Position=data.Pos});
                if (find is null || find?.Count() < 1)
                    query = "Insert Into tbl_data(Model,Position,X,Y,Z,CameraCheckPoint) Values(@Model,@Position,@X,@Y,@Z,@c)";
                else
                    query = "Update tbl_data set X=@X,Y=@Y,Z=@Z,CameraCheckPoint=@c where Model=@Model and Position=@Position";
                await conn.ExecuteAsync(query,new {Model= data.Model,Position=data.Pos,X=data.X,Y=data.Y,Z=data.Z,c=data.CameraCheckpoint});
                if (find is null || find?.Count() < 1)
                    await SaveCamPoint(data, data.CameraPoint!.Value);
                else
                    await SaveCamPoint(find!.First(),data.CameraPoint!.Value);
            }
        }
        public async Task FullCopyPosition(string oldModelName,string newModelName)
        {
            string[] queries = new string[]
                {
                    "Insert Into tbl_data(Model,Position,X,Y,Z,CameraCheckPoint) Select @newModelName,Position,x,y,z,CameraCheckPoint From TBl_Data where model=@oldModelName;",
                    "Insert Into Tbl_CamPoint(Model,CameraPoint,Pitching,CavityTotal) Select @newModelName,CameraPoint,Pitching,CavityTotal From Tbl_CamPoint where model=@oldModelName",
                    "Insert Into Tbl_MarkPoint(Model,Position,AreaInspection,X,Y,ImageName) Select @newModelName,Position,AreaInspection,X,Y,ImageName From TBl_MarkPoint Where model=@oldModelName",
                    "Insert Into Tbl_Image(Model,Position,ImageName,AreaInspection,No) Select @newModelName,Position,ImageName,AreaInspection,No From Tbl_Image Where Model=@oldModelName"
                };
            using (var conn = GetConn())
            {
                await conn.OpenAsync();
                using (var transact = await conn.BeginTransactionAsync())
                {

                    int res = await conn.ExecuteAsync(queries[0], new { oldModelName = oldModelName, newModelName = newModelName }, transaction: transact);
                    if (res < 1)
                    {
                        await transact.RollbackAsync();
                        return;
                    }
                    for (int i=1;i<queries.Length; i++)
                        await conn.ExecuteAsync(queries[i],new {oldModelName=oldModelName,newModelName=newModelName},transaction:transact);
                    await transact.CommitAsync();
                }
            }
        }
        public async Task SaveCamPoint(PosView data,int newCampoint)
        {
            using (var conn = GetConn())
            {
                await conn.OpenAsync();
                string query = "Select d.Model,Position as Pos,d.X,d.Y,d.Z,d.CameraCheckPoint,c.CameraPoint From Tbl_Data d right join tbl_campoint c on d.model=c.model Where c.Model=@Model;";
                IEnumerable<PosView>? find = await conn.QueryAsync<PosView>(query, new { Model = data.Model, Position = data.Pos },commandTimeout: 60);
                if (find is null || find?.Count() < 1)
                    query = "Insert into tbl_campoint(Model,CameraPoint) Values(@model,@c);";
                else
                    query = "Update tbl_campoint set CameraPoint=@c where model=@model ;";
                await conn.ExecuteAsync(query, new { model = data.Model, c = newCampoint });
            }
        }
        public async Task DeletePosition(PositionModel data)
        {
            using (var conn = GetConn())
            {
                await conn.OpenAsync();
                string query = "Delete Tbl_Data where Model=@model and Position=@pos;";
                await conn.ExecuteAsync(query, new { model = data.Model, pos = data.Pos });
                query = "Update Tbl_Data set Position=Position-1 where Model=@model and Position > @pos and @pos>0;";
                await conn.ExecuteAsync(query, new { model = data.Model, pos = data.Pos });
            }
        }
        public async Task DeletePosition(string model)
        {
            using (var conn = GetConn())
            {
                await conn.OpenAsync();
                string query = "Delete Tbl_Data where model=@model";
                await conn.ExecuteAsync(query,new {model = model });
                query = "Delete From tbl_Campoint where model=@model";
                await conn.ExecuteAsync(query, new { model = model });
            }
        }
        public async Task InsertAter(int insertAfterPos,PosView data)
        {
            using (var conn = GetConn())
            {
                await conn.OpenAsync();
                string query = "Update Tbl_Data set Position=Position+1 where Model=@model and Position > @pos;";
                await conn.ExecuteAsync(query, new { model = data.Model, pos = insertAfterPos });
            }
            data.Pos = insertAfterPos+1;
            await SavePosition(data);
        }
        public async Task<List<PositionModel>> GetPositions(bool? isActive= null)
        {
            List<PositionModel> list = new List<PositionModel>();
            using (var conn = GetConn())
            {
                await conn.OpenAsync();
                string isActiveQuery = string.Empty;
                if (isActive is not null)
                    isActiveQuery = $"Where isActive={(isActive.Value ? "1": "0")}";
                string query = $"Select Model,Position as Pos,X,Y,Z,CameraCheckPoint From Tbl_Data {isActiveQuery}  Order By Model Asc";
                var find = await conn.QueryAsync<PositionModel>(query);
                if (find != null && find?.Count() > 0)
                    list = find.ToList();
            }
            return list;
        }
        public async Task<List<PositionModel>> GetPositionByModel(string Model)
        {
            List<PositionModel> list = new List<PositionModel>();
            using (var conn = GetConn())
            {
                await conn.OpenAsync();
                string query = "Select Model,Position as Pos,X,Y,Z,CameraCheckPoint From Tbl_Data Where Model=@Model Order By Position Asc";
                var find = await conn.QueryAsync<PositionModel>(query,new {Model=Model});
                if (find != null && find?.Count() > 0)
                    list = find.ToList();
            }
            return list;
        }
        public async Task<List<ImageAreaModel>> GetAreaImageByModel(string Model)
        {
            List<ImageAreaModel> list = new List<ImageAreaModel>();
            using (var conn = GetConn())
            {
                await conn.OpenAsync();
                string query = "Select Model,Position,No,AreaInspection,ImageName as Image From Tbl_Image Where Model=@Model Order By Position,No Asc";
                var find = await conn.QueryAsync<ImageAreaModel>(query, new { Model = Model });
                if (find != null && find?.Count() > 0)
                    list = find.ToList();
            }
            return list;
        }
        public async Task<List<ImageAreaModel>> GetAreaImageByModel(string Model,int Position)
        {
            List<ImageAreaModel> list = new List<ImageAreaModel>();
            using (var conn = GetConn())
            {
                await conn.OpenAsync();
                string query = "Select Model,Position,No,AreaInspection,ImageName as Image From Tbl_Image Where Model=@Model and Position=@Position  Order By Position,No Asc";
                var find = await conn.QueryAsync<ImageAreaModel>(query, new { Model = Model,Position=Position });
                if (find != null && find?.Count() > 0)
                    list = find.ToList();
            }
            return list;
        }
        public async Task<List<ImageAreaModel>> GetAreaImageByModel(string Model, int Position,int no)
        {
            List<ImageAreaModel> list = new List<ImageAreaModel>();
            using (var conn = GetConn())
            {
                await conn.OpenAsync();
                string query = "Select Model,Position,No,AreaInspection,ImageName as Image From Tbl_Image Where Model=@Model and Position=@Position and No=@no Order By Position,No Asc";
                var find = await conn.QueryAsync<ImageAreaModel>(query, new { Model = Model, Position = Position,no=no });
                if (find != null && find?.Count() > 0)
                    list = find.ToList();
            }
            return list;
        }
        public async Task DeleteAreaImage(string model,int position,int no)
        {
            using (var conn = GetConn())
            {
                await conn.OpenAsync();
                string query = "Delete Tbl_Image Where model=@model and position=@position and No=@no;";
                await conn.ExecuteAsync(query, new { model = model, position = position, No=@no });
                var areaImages = await GetAreaImageByModel(model, position);
                if (areaImages.Count > 0)
                {
                    query = "Update TBl_Image set No=No-1 where model=@model and position=@position and No > @no";
                    await conn.ExecuteAsync(query, new { model = model, position = position, no = no });
                }
                else
                {
                    query = "Update Tbl_Image set Position=Position-1 where model=@model and position > @position;";
                    await conn.ExecuteAsync(query, new { model = model, position = position});
                }
            }
        }
        public async Task SavePosRecord(RecordInspectionModel record)
        {
            using (var conn = GetConn())
            {
                await conn.OpenAsync();
                string query = "Insert Into Tbl_Record(Model,Position,X,Y,Z,CameraCheckPoint,AreaInspection,ScanCode,Judgement,ProcessDate,FileName,Reason) Values(@Model,@Position,@X,@Y,@Z,@c,@area,@scanCode,@judgement,GETDATE(),@filename,@reason)";
                await conn.ExecuteAsync(query, new { Model = record.Model, Position = record.Pos, X = record.X, Y = record.Y, Z = record.Z, c = record.CameraCheckpoint, area = record.AreaInspection,scanCode=record.ScanCode,judgement=record.Judgement,filename=record.FileName,reason=record.Reason });
            }
        }
        public async Task DeleteRecord(RecordInspectionModel record)
        {
            StringBuilder query = new StringBuilder("Delete From TBl_Record Where ProcessDate Between @from and @to and ScanCode=@ScanCode and Model=@Model and Position=@Position and AreaInspection=@AreaInspection");
            using (var conn=  GetConn())
            {
                await conn.OpenAsync();
                await conn.ExecuteAsync(query.ToString(), new { from = record.ProcessDate.AddDays(-1), to = record.ProcessDate.AddDays(1), ScanCode = record.ScanCode, Model = record.Model, Position = record.Pos, AreaInspection = record.AreaInspection });
            }
        }
        public async Task<IEnumerable<RecordInspectionModel>> GetPosRecord( DateTime from ,DateTime to,string? scanCode= null, string? model = null)
        {
            using (var conn = GetConn())
            {
                await conn.OpenAsync();
                StringBuilder query = new StringBuilder("Select Model,Position as Pos,X,Y,Z,CameraCheckPoint,AreaInspection,ScanCode,Judgement,ProcessDate,FileName,Reason From TBl_Record Where ProcessDate Between @from and @to and ");
                List<string> additionalCondition = new List<string>(2);
                if (model is not null)
                    additionalCondition.Add("model=@model");
                if (scanCode is not null)
                    additionalCondition.Add("ScanCode=@scanCode");
                if (additionalCondition.Count > 0)
                    query.Append(string.Join(" and ", additionalCondition.ToArray()));
                var records = await conn.QueryAsync<RecordInspectionModel>(query.ToString(),new {from=from,to=to,scanCode=scanCode,model=model});
                return records;
            }
        }
        public async Task SaveImage(ImageAreaModel model)
        {
            using (var conn = GetConn())
            {
                await conn.OpenAsync();
                string query = "Select Count(*) as c from Tbl_Image where Model=@model and position=@position and No=@no";
                var res = await conn.ExecuteReaderAsync(query, new { model = model.Model, position = model.Position,no=model.No });
                await res.ReadAsync();
                int c = int.Parse(res[0]?.ToString() ?? "0");
                await res.CloseAsync();
                if (c < 1)
                    query = "Insert into Tbl_image(model,position,imageName,AreaInspection,No) Values(@Model,@Position,@Image,@AreaInspection,@No)";
                else
                    query = "Update Tbl_Image set imageName=@Image,AreaInspection=@AreaInspection where model=@Model and position=@Position and No=@No";
                await conn.ExecuteAsync(query, model);
            }
        }
        public async Task<string> GetLocalImage(ImageAreaModel model)
        {
            string img = string.Empty;
            using (var conn = GetConn())
            {
                await conn.OpenAsync();
                string query = "Select imageName From Tbl_Image where Model=@model and Position=@pos and no=@No";
                var rd = await conn.ExecuteReaderAsync(query, new { model = model.Model, pos = model.Position,no=model.No });
                if (await rd.ReadAsync())
                {
                    img = rd[0].ToString() ?? string.Empty;
                }

            }
            return img;
        }
        public async Task<List<PosView>> GetPosView(string Model)
        {
            List<PosView> list = new List<PosView>();
            using (var conn = GetConn())
            {
                await conn.OpenAsync();
                string query = "Select d.*,c.CameraPoint From tbl_data d left join tbl_campoint c on d.model=c.model  where d.model=@model";
                var l= await conn.QueryAsync<PosView>(query, new { model = Model });
                list = l.ToList();
            }
            return list;
        }
        public async Task<int?> GetCamPoint(string model)
        {
            int? point = null;
            using (var conn= GetConn())
            {
                await conn.OpenAsync();
                string query = "Select camerapoint from tbl_campoint where model=@model;";
                var rd = await conn.ExecuteReaderAsync(query, new { model = model });
                bool r = await rd.ReadAsync();
                point = r ? int.Parse(rd[0].ToString() ?? "-1") : 0;
            }
            return point;
        }
        public async Task<CavityModel?> GetCavity(string model)
        {
            CavityModel? result;
            using (var conn=GetConn())
            {
                await conn.OpenAsync();
                string query = "Select Pitching,CavityTotal From Tbl_Campoint where model=@model";
                var res = await conn.QueryAsync<CavityModel>(query, new { model = model });
                result = res.FirstOrDefault();
            }
            return result;
        }
        public async Task SaveCavity(string Model,CavityModel data)
        {
            var camPoint = await GetCamPoint(Model);
            using (var conn = GetConn())
            {
                await conn.OpenAsync();
                string query = string.Empty;
                if (camPoint is null || camPoint == -1)
                    query = "Insert Into Tbl_CamPoint(Model,CameraPoint,Pitching,CavityTotal) values(@Model,-2,@Pitching,@CavityTotal)";
                else
                    query = "Update Tbl_Campoint set Pitching=@Pitching,CavityTotal=@CavityTotal Where Model=@model";
                await conn.ExecuteAsync(query,new {model= Model, Pitching=data.Pitching,CavityTotal=data.CavityTotal});
            }
        }

        public async Task SaveMarkPoint(MarkPointModel model)
        {
            using (var con= GetConn())
            {
                await con.OpenAsync();
                string query = "Insert Into Tbl_MarkPoint(Model,Position,AreaInspection,X,Y,ImageName) Values(@Model,@Position,@AreaInspection,@X,@Y,@ImageName)";
                await con.ExecuteAsync(query, model);
            }
        }

        public async Task RemoveMarkPoint(MarkPointModel model)
        {
            using (var con = GetConn())
            {
                await con.OpenAsync();
                string query = "Delete Tbl_MarkPoint Where Model=@Model and Position=@Position;";
                await con.ExecuteAsync(query, model);
            }
        }

        public async Task<IEnumerable<MarkPointModel>?> GetMarkPoint(string model)
        {
            IEnumerable<MarkPointModel>? list = null;
            using (var con = GetConn())
            {
                await con.OpenAsync();
                string query = "Select Model,Position,AreaInspection,X,Y,ImageName From tbl_MarkPoint where Model=@model";
                list = await con.QueryAsync<MarkPointModel>(query, new { model=model});
            }
            return list;
        }

        public async Task<IEnumerable<MarkPointModel>?> GetMarkPoint(string model, string area)
        {
            IEnumerable<MarkPointModel>? list = null;
            using (var con = GetConn())
            {
                await con.OpenAsync();
                string query = "Select Model,Position,ImageName,AreaInspection,X,Y From tbl_MarkPoint where Model=@model and AreaInspection=@area";
                list = await con.QueryAsync<MarkPointModel>(query, new {model=model,area=area});
            }
            return list;
        }

        public async Task ClearMarkPoint(string model)
        {
            using (var con = GetConn())
            {
                await con.OpenAsync();
                string query = "Delete Tbl_MarkPoint Where Model=@Model ;";
                await con.ExecuteAsync(query, new { Model = model});
            }
        }
    }
}
