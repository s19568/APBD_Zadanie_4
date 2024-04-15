// This call WebApplication.CreateBuilder() creates an object that represents our application 
// This variable allows our application to be configured before it will be excecuted
// Builder pattern - design patter (classic design patterns of objective programming

using APBD_Zadanie_4;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/animals", () =>
{
    var animals = AnimalsDataStore.Current.GetAnimals();
    return Results.Ok(animals);
});

app.MapGet("/animals/{id}", (int id) =>
{
    var animal = AnimalsDataStore.Current.GetAnimalById(id);
    return animal?.Id != null ? Results.Ok(animal) : Results.NotFound();
});

app.MapPost("/animals", (Animal animal) =>
{
    AnimalsDataStore.Current.AddAnimal(animal);
    return Results.Created($"/animals/{animal.Id}", animal);
});

app.MapPut("/animals/{id}", (int id, Animal animal) =>
{
    if (AnimalsDataStore.Current.UpdateAnimal(id, animal))
        return Results.Ok();
    else
        return Results.NotFound();
});

app.MapDelete("/animals/{id}", (int id) =>
{
    if (AnimalsDataStore.Current.DeleteAnimal(id))
        return Results.Ok();
    else
        return Results.NotFound();
});

app.MapGet("/visits/{animalId}", (int animalId) =>
{
    var visits = VisitDataStore.Current.GetVisitsByAnimalId(animalId);
    return Results.Ok(visits);
});

app.MapPost("/visits", (Visit visit) =>
{
    VisitDataStore.Current.AddVisit(visit);
    return Results.Created($"/visits/{visit.visit_ID}", visit);
});

//Get's all visits and display all animals
//
// app.MapGet("/visits", () =>
// {
//     var visits = VisitDataStore.Current.GetAllVisits();
//     return Results.Ok(visits);
// });

app.MapControllers();

app.Run();



