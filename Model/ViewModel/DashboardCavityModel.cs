using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTCP1.Model.ViewModel
{
    public class DashboardCavityModel
    {
        public decimal CurrentPitching { get; private set; } = 0;
        public int CurrentCavity { get; set; } = 0;
        public CavityModel Cavity { get; set; } = new CavityModel();
        public List<CavityItemModel> Cavities { get;private set; }
        public DashboardCavityModel(int _pitching, int cavityNumber)
        {
            Cavity.CavityTotal = cavityNumber;
            Cavity.Pitching = _pitching;
            Cavities = new List<CavityItemModel>();
        }
        public DashboardCavityModel(CavityModel cavity,List<PositionModel> Positions)
        {
            Cavity = cavity;
            Cavities = new List<CavityItemModel>();
            SetupCavities(Positions);
        }
        public void Next( int multiplier = 0)
        {
            CurrentPitching = Cavity.Pitching * multiplier;
        }
        
        public PositionModel Transform( PositionModel model )
        {
            PositionModel newPos = new PositionModel()
            {
                X = model.X,
                Y = model.Y,
                Z = model.Z,
                AreaInspection = model.AreaInspection,
                CameraCheckpoint = model.CameraCheckpoint,
                Model = model.Model,
                Pos = model.Pos
            };
            newPos.X += CurrentPitching;
            return newPos;
        }
        public void SetupCavities(List<PositionModel> models)
        {
            CurrentCavity = 0;
            for (int i=0;i<Cavity.CavityTotal;i++) 
            {
                CavityItemModel item = new CavityItemModel();
                item.CavityNo = i;
                item.Models = new List<PositionModel>();
                CurrentPitching = Cavity.Pitching * i;
                foreach (var model in models)
                {
                    item.Models.Add(Transform(model));
                }
                Cavities.Add(item);
            }

        }
        public bool isCavitiesPass()
        {
           return !Cavities.Any(x => x.isNg());
        }
        public void AddToImageList(int cavityNo,string areaName, string actualImage,string ngImage)
        {
            if (Cavities.ElementAtOrDefault(cavityNo) == null)
                return;
            Cavities[cavityNo].ImageList.Add(areaName, new Tuple<string, string>(actualImage,ngImage));
        }
        public void ClearImageList()
        {
            for (int i=0;i<Cavities.Count;i++)
                Cavities[i].ImageList.Clear();
        }
        public void ClearImageList(int cavityNo)
        {
            Cavities[cavityNo].ImageList.Clear();
        }
        public CavityItemModel CurrentCavityItem {
            get => Cavities[CurrentCavity];
        }
    }
    public class CavityModel 
    {

        public int CavityTotal { get; set; } = 0;
        public decimal Pitching { get; set; } = 0;
    }

    public class CavityItemModel
    {
        public int CavityNo { get; set; }
        public List<PositionModel> Models { get; set; } = new List<PositionModel>();
        public Dictionary<string, Tuple<string, string>> ImageList = new Dictionary<string, Tuple<string, string>>();
        public string SerialNumber { get; set; } = string.Empty;
        public List<InspectionView> InspectionViews { get; set; } = new List<InspectionView>();

        public bool isNg()
        {
            return InspectionViews.Any(x => x.Judgement.ToUpper() == "NG");
        }
    }
    
}
