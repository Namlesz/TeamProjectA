using NBomber.CSharp;
using NBomber.Http.CSharp;
using NUnit.Framework;

namespace TeamProjectA.Tests.NBomberTest;

public class AuthControllerStressTest
{
    [Test]
    public void Login_stress_test_20_requests_per_second_10_sec_duration()
    {
        const string login = "login_test";
        var httpClient = new HttpClient();

        var scenario = Scenario.Create("http_scenario", async _ =>
            {
                var request =
                    Http.CreateRequest("POST",
                            $"https://localhost:7188/api/Auth/Login?Login={login}")
                        .WithHeader("Accept", "application/json");

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