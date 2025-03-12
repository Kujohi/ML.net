using Microsoft.ML.Data;
using Microsoft.Extensions.ML;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPredictionEnginePool<ModelInput, ModelOutput>()
    .FromFile(modelName: "MovieRecommender", filePath: "MovieRecommenderModel.zip", watchForChanges: true);

var app = builder.Build();

app.MapGet("/api/recommendation", 
    (PredictionEnginePool<ModelInput, ModelOutput> predictionEnginePool, 
     float userId, 
     float movieId) =>
{
    var input = new ModelInput { userId = userId, movieId = movieId };
    var prediction = predictionEnginePool.Predict(modelName: "MovieRecommender", input);
    return Results.Json(new { userId, movieId, rating = prediction.rating });
});

app.Run();

public class ModelInput
{
    public float userId;
    public float movieId;
}

public class ModelOutput
{
    [ColumnName("Score")]
    public float rating ;
}