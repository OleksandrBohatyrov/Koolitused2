using Autofac.Integration.Mvc;
using Autofac;
using Koolitused.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Koolitused;

public class AutofacConfig
{
    public static void Configure()
    {
        var builder = new ContainerBuilder();

        // Регистрируем контроллеры в контейнере
        builder.RegisterControllers(typeof(MvcApplication).Assembly);

        // Регистрируем контексты баз данных
        builder.RegisterType<GuestContext>().AsSelf().InstancePerRequest();
        builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();

        // Регистрируем другие зависимости
        // Например, если у вас есть сервис GuestService, зарегистрируйте его
        // builder.RegisterType<GuestService>().As<IGuestService>().InstancePerRequest();

        // Строим контейнер
        var container = builder.Build();

        // Устанавливаем DependencyResolver
        DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    }
}