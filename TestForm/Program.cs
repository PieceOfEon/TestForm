using System.Runtime.InteropServices;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();


app.Run(async (context) =>
{

    context.Response.ContentType = "text/html";

    if (context.Request.Path == "/postuser")
    {
        var form = context.Request.Form;
        var score = 0;

        var question1Answer = form["question1"];
        var question2Answer = form["question2"];
        var question3Answer = form["question3"];

        // Правильные ответы на вопросы
        var correctAnswer1 = "a";
        var correctAnswer2 = "b";
        var correctAnswer3 = "b";

        // Проверка ответов и подсчет результатов
        

        if (question1Answer == correctAnswer1)
        {
            score += 1;
        }

        if (question2Answer == correctAnswer2)
        {
            score += 1;
        }

        if (question3Answer == correctAnswer3)
        {
            score += 1;
        }
        // Установка кодировки
        context.Response.ContentType = "text/html; charset=utf-8";
        // Вывод результатов теста
        await context.Response.WriteAsync($"Вы набрали {score} из 3 баллов.");
    }
    else
    {
        await context.Response.SendFileAsync("html/index.html");
    }

});

app.Run();
