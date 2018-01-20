using Sales.ReadModels.Service.Views;
using MicroServices.Common.MessageBus;
using StackExchange.Redis;

namespace Sales.ReadModels.Service
{
    public static class ServiceLocator
    {
        public static IMessageBus Bus { get; set; }
        public static OrderView BrandView { get; set; }
    }
}