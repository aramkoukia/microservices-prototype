using Products.ReadModels.Service.Views;
using MicroServices.Common.MessageBus;

namespace Products.ReadModels.Service
{
    public static class ServiceLocator
    {
        public static IMessageBus Bus { get; set; }
        public static ProductView ProductView { get; set; }
    }
}