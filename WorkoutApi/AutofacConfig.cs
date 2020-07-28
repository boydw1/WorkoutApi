using Autofac;
using WorkoutApi.Services;
using WorkoutApi.Services.Interfaces;

namespace WorkoutApi
{
    public static class AutofacConfig
    {
        public static IContainer Container;

        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<WorkoutService>();
            builder.RegisterType<WorkoutService>().As<IWorkoutService>();
            builder.RegisterType<DataService>();
            builder.RegisterType<DataService>().As<IDataService>();
            
            Container = builder.Build(); 

            return builder.Build();
        }        
    }
}