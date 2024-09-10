using AutoMapper;
using IntraVisionTest.Domain;

namespace IntraVisionTest.Application
{
    public abstract class IntraVisionAppService
    {
        protected IntraVisionContext Context { get; set; }

        protected Domain.Entities.ShopCard? ShopCard { get; set; }

        protected IMapper Mapper { get; set; }

        protected IntraVisionAppService(IntraVisionContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        protected IntraVisionAppService(IntraVisionContext context, Domain.Entities.ShopCard shopCard, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
            ShopCard = shopCard;
        }
    }
}
