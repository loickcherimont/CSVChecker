Imports System.Web.Optimization

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Se déclenche lorsque l'application est démarrée
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        'Load .env content when app is up
        DotNetEnv.Env.Load(System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, ".env"))
    End Sub
End Class