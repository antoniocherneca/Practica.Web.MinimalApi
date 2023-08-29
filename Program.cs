using Microsoft.EntityFrameworkCore;
using Practica.Web.MinimalApi.Data;
using Practica.Web.MinimalApi.Data.Interfaces;
using Practica.Web.MinimalApi.Data.Repositories;
using Practica.Web.MinimalApi.Models;

namespace Practica.Web.MinimalApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MoviesDbContext>(options => options.UseInMemoryDatabase("MoviesDb"));
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddDbContext<ClientsDbContext>(options => options.UseInMemoryDatabase("ClientsDb"));
            builder.Services.AddScoped<IClientRepository, ClientRepository>();

            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/api/movies", (IMovieRepository movieRepository) =>
            {
                var movies = movieRepository.GetAllMovies();
                if (movies != null)
                {
                    return Results.Ok(movies);
                }
                return Results.NotFound("No se encontraron películas.");
            });

            app.MapGet("/api/movies/{id}", (IMovieRepository movieRepository, int id) =>
            {
                var movie = movieRepository.GetMovieById(id);
                if (movie != null)
                {
                    return Results.Ok(movie);
                }
                return Results.NotFound("No se encontró la película buscada.");
            });

            app.MapPost("/api/movies", (IMovieRepository movieRepository, Movie movie) =>
            {
                movieRepository.CreateMovie(movie);
                return Results.Ok("Película creada con éxito.");
            });

            app.MapPut("/api/movies/{id}", (IMovieRepository movieRepository, int id, Movie updatedMovie) =>
            {
                var movie = movieRepository.GetMovieById(id);
                if (movie != null)
                {
                    movie.Description = updatedMovie.Description;
                    movie.Duration = updatedMovie.Duration;
                    movie.Gender = updatedMovie.Gender;
                    movieRepository.UpdateMovie(movie);
                    return Results.Ok("Película actualizada con éxito.");
                }
                return Results.NotFound("No se encontró la película a actualizar.");
            });

            app.MapDelete("/api/movies/{id}", (IMovieRepository movieRepository, int id) =>
            {
                var movie = movieRepository.GetMovieById(id);
                if (movie != null)
                {
                    movieRepository.DeleteMovie(id);
                    return Results.Ok("Película eliminada con éxito.");
                }
                return Results.NotFound("No se encontró la película a eliminar.");
            });

            app.MapGet("/api/clients", (IClientRepository clientRepository) =>
            {
                var clients = clientRepository.GetAllClients();
                if (clients != null)
                {
                    return Results.Ok(clients);
                }
                return Results.NotFound("No se encontraron clientes.");
            });

            app.MapGet("/api/clients/{id}", (IClientRepository clientRepository, int id) =>
            {
                var client = clientRepository.GetClientById(id);
                if (client != null)
                {
                    return Results.Ok(client);
                }
                return Results.NotFound("No se encontró el cliente buscado.");
            });

            app.MapPost("/api/clients", (IClientRepository clientRepository, Client client) =>
            {
                clientRepository.CreateClient(client);
                return Results.Ok("Cliente creado con éxito.");
            });

            app.MapPut("/api/clients/{id}", (IClientRepository clientRepository, int id, Client updatedClient) =>
            {
                var client = clientRepository.GetClientById(id);
                if (client != null)
                {
                    client.Name = updatedClient.Name;
                    client.LastName = updatedClient.LastName;
                    client.Address = updatedClient.Address;
                    clientRepository.UpdateClient(client);
                    return Results.Ok("Cliente actualizado con éxito.");
                }
                return Results.NotFound("No se encontró el cliente a actualizar.");
            });

            app.MapDelete("/api/clients/{id}", (IClientRepository clientRepository, int id) =>
            {
                var client = clientRepository.GetClientById(id);
                if (client != null)
                {
                    clientRepository.DeleteClient(id);
                    return Results.Ok("Cliente eliminado con éxito.");
                }
                return Results.NotFound("No se encontró el cliente a eliminar.");
            });

            app.Run();
        }
    }
}