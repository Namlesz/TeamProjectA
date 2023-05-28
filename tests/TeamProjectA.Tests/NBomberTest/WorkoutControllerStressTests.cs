using NBomber.CSharp;
using NBomber.Http.CSharp;
using NUnit.Framework;

namespace TeamProjectA.Tests.NBomberTest;

public class WorkoutControllerStressTests
{
    [Test]
    public void GetWorkoutDetails_stress_test_60_requests_per_second_5_sec_duration()
    {
        const string workoutId = "24ed49c3-a0d9-44db-9951-1c3c32bf2ecd";
        var httpClient = new HttpClient();

        var scenario = Scenario.Create("http_scenario", async _ =>
            {
                var request =
                    Http.CreateRequest("GET",
                            $"https://localhost:7188/api/Workouts/GetWorkoutDetails?Id={workoutId}")
                        .WithHeader("Accept", "application/json")
                        .WithHeader("Authorization", "bearer " + TokenGenerator.GeTestToken());

                var response = await Http.Send(httpClient, request);

                return response;
            })
            .WithLoadSimulations(
                Simulation.Inject(rate: 60,
                    interval: TimeSpan.FromSeconds(1),
                    during: TimeSpan.FromSeconds(5))
            ).WithoutWarmUp();

        NBomberRunner
            .RegisterScenarios(scenario)
            .Run();
    }

    [Test]
    public void GetWorkouts_stress_test_20_requests_per_second_10_sec_duration()
    {
        var httpClient = new HttpClient();

        var scenario = Scenario.Create("http_scenario", async _ =>
            {
                var request =
                    Http.CreateRequest("GET",
                            $"https://localhost:7188/api/Workouts/GetWorkouts")
                        .WithHeader("Accept", "application/json")
                        .WithHeader("Authorization", "bearer " + TokenGenerator.GeTestToken());

                var response = await Http.Send(httpClient, request);

                return response;
            })
            .WithLoadSimulations(
                Simulation.Inject(rate: 20,
                    interval: TimeSpan.FromSeconds(1),
                    during: TimeSpan.FromSeconds(10))
            ).WithoutWarmUp();

        NBomberRunner
            .RegisterScenarios(scenario)
            .Run();
    }
}