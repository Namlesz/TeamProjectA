using NBomber.CSharp;
using NBomber.Http.CSharp;
using NUnit.Framework;

namespace TeamProjectA.Tests.NBomberTest;

public class TrainerControllerStressTest
{
    [Test]
    public void SearchTrainer_stress_test_50_requests_per_second_10_sec_duration()
    {
        const string login = "abc";
        var httpClient = new HttpClient();

        var scenario = Scenario.Create("http_scenario", async _ =>
            {
                var request =
                    Http.CreateRequest("GET",
                            $"https://localhost:7188/api/Trainer/SearchTrainer?Login={login}")
                        .WithHeader("Accept", "application/json")
                        .WithHeader("Authorization", "bearer " + TokenGenerator.GeTestToken());

                var response = await Http.Send(httpClient, request);

                return response;
            })
            .WithLoadSimulations(
                Simulation.Inject(rate: 50,
                    interval: TimeSpan.FromSeconds(1),
                    during: TimeSpan.FromSeconds(10))
            ).WithoutWarmUp();

        NBomberRunner
            .RegisterScenarios(scenario)
            .Run();
    }
}