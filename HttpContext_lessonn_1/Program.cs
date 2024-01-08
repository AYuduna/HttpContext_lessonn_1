//ASP(англ.Active Server Pages — «активные серверные страницы»)
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();




////1
//app.UseWelcomePage();
//app.Run();


//2
//int x = 2;
//app.Run(async context =>
//{

//    x *= 2;
//    await context.Response.WriteAsync(x.ToString());
//});
//app.Run();


////3
//app.Run(async (context) =>
//{
//    var response = context.Response;
//    response.Headers.ContentLanguage = "eng-Eng";
//    response.Headers.ContentType = "text/plain; charset=utf-8";
//    response.Headers.Append("parameter", "100");    // добавление пользовательского заголовка
//    response.StatusCode = 404;
//    await response.WriteAsync("Строка с хедерами");
//});

////4
//app.Run(async (context) =>
//{
//    var response = context.Response;
//    response.ContentType = "text/html; charset=utf-8";
//    await response.WriteAsync("<h2>This is HTML h2</h2><h3>Текст h3</h3>");
//});

////5
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    var stringBuilder = new System.Text.StringBuilder("<table>");

//    foreach (var header in context.Request.Headers)
//    {
//        stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
//    }
//    stringBuilder.Append("</table>");
//    await context.Response.WriteAsync(stringBuilder.ToString());
//});


////6
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    await context.Response.WriteAsync($"<p>Path: {context.Request.Path}</p>" +
//        $"<p>QueryString: {context.Request.QueryString}</p>");  //https://localhost:44391/123?param=1
//});

////7
//app.Run(async (context) =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    var stringBuilder = new System.Text.StringBuilder("<h3>Параметры строки запроса</h3><table>");
//    stringBuilder.Append("<tr><td>Параметр</td><td>Значение</td></tr>");
//    foreach (var param in context.Request.Query)
//    {
//        stringBuilder.Append($"<tr><td>{param.Key}</td><td>{param.Value}</td></tr>");
//    }
//    stringBuilder.Append("</table>");
//    await context.Response.WriteAsync(stringBuilder.ToString());
//});

//8
//app.Run(async (context) =>
//{
//context.Response.ContentType = "text/html; charset=utf-8";
//context.Response.Headers.ContentDisposition = "attachment; filename=my_html.html";
//await context.Response.SendFileAsync("html/htmlpage.html");

//});


////9
//int x = 2;

//app.Map("/", async context =>
//                    {
//                        x *= 2;
//                        await context.Response.WriteAsync($"Hello world x={x}");
//});

//app.Map("/1", async context =>
//{
//    x *= 10;
//    await context.Response.WriteAsync($"Hello world-1! x={x}");
//});

//app.Map("/2", async context =>
//{
//    Thread.Sleep(5000);
//     context.Response.Redirect("/");
//});




////10
//app.MapWhen(context =>
//{
//    return context.Request.Query.ContainsKey("size") &&
//            context.Request.Query["size"] == "5";
//}, HandleId);


//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Good bye, World...");

//});


//static void HandleId(IApplicationBuilder app)
//{
//    app.Run(async context =>
//    {

//        await context.Response.WriteAsync("size is equal " + context.Request.Query["size"]);
//    });
//}


////11
app.Map("/", async context =>
{
    var response = context.Response;
    response.ContentType = "text/html; charset=utf-8";
    string path = "https://"+context.Request.Host + context.Request.Path;
   
    //await response.WriteAsync("<form action=\"http://localhost:5125/1\">\r\n <input type=\"submit\" value=\"Goto page1\"/>\r\n</form>");
    //await response.WriteAsync("<form action=\"http://localhost:5125/1\">\r\n <button type=\"submit\">Goto page1</button>\r\n</form>");
    path = path+"1";
    await response.WriteAsync($"<form action= {path} method = \"POST\">\r\n <input type=\"submit\" value=\"Goto page1\"/>\r\n</form>");
});

app.Map("/1", async context =>
{
    var response = context.Response;
    response.Headers.ContentType = "text/plain;charset=utf-8";
    await response.WriteAsync("Страница 1");
});


app.Run(); 
