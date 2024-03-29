using MyFeedRss.Application.FeedsRss;
using MyFeedRss.Application.Posts;
using MyFeedRss.Components;
using MyFeedRss.Infrastructure.FeedRss;
using MyFeedRss.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddTransient<IFeedRssService, FeedRssService>();
builder.Services.AddTransient<IFeedRssRepository, FeedRssRepository>();

builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IPostFeedRssReader, PostFeedRssReader>();
builder.Services.AddTransient<IFeedRssRepository, FeedRssRepository>();
builder.Services.AddTransient<IPostRepository, PostRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MyFeedRss.Client._Imports).Assembly);

app.Run();
