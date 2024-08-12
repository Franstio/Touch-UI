using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTCP1.Model;

namespace TestTCP1
{
    public class AutoMapConfig
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PositionModel, JudgementView>();
                cfg.CreateMap<PositionModel,ModelPosView>().ForMember(a=>a.Axis,b=>b.MapFrom(c=>$"{c.X}, {c.Y}, {c.Z}"));
                cfg.CreateMap<PositionModel, InspectionView>();
                cfg.CreateMap<PositionModel, RecordInspectionModel>();
                cfg.CreateMap<PositionModel, PosView>();
                });
            return new Mapper(config);
        }
    }
}
