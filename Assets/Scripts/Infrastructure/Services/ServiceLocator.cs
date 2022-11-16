namespace Infrastructure.Services
{
    public class ServiceLocator
    {
        private static ServiceLocator _instance;

        //возвращает _instance или new ServiceLocator
        public static ServiceLocator Container => _instance ?? (_instance = new ServiceLocator());

        //регистрация сервиса
        public void RegisterService<TService>(TService implementation) where TService : IService => 
            Implementation<TService>.ServiceInstance = implementation;

        //получение сервиса
        public TService GetService<TService>() where TService : IService => Implementation<TService>.ServiceInstance;


        //служебный класс для хранения реализации сервиса
        private static class Implementation<TService> where TService:IService
        {
            public static TService ServiceInstance;
        }
    }
}
