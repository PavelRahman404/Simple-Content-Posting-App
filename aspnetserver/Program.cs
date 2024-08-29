using aspnetserver.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/get-all-posts", async () => await PostRepository.GetPostsAsync()).WithTags("Post Endpoints");

app.MapGet("/get-post-by-id/{postId}", async (int postId) =>
{
    Post postToReturn = await PostRepository.GetPostsAsyncById(postId);
    if (postToReturn != null)
    {
        return Results.Ok(postToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Post Endpoints");

app.MapPost("/create-post", async (Post postToCreate) =>
{
    bool createSuccessful = await PostRepository.CreatePostsAsync(postToCreate);
    if (createSuccessful)
    {
        return Results.Ok("Create Successful");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");

app.MapPut("/update-post", async (Post postToUpdate) =>
{
    bool updateSuccessful = await PostRepository.UpdatePostsAsync(postToUpdate);
    if (updateSuccessful)
    {
        return Results.Ok("Update Successful");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");

app.MapDelete("/delete-post-by-id/{postId}", async (int postId) =>
{
    bool deleteSuccessful = await PostRepository.DeletePostsAsync(postId);
    if (deleteSuccessful)
    {
        return Results.Ok("Delete Successful");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");

app.Run();


