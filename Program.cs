namespace TheSixthProgram3._1
{
    delegate Tuple<int, int, string> PlanetValidator(string message);
    internal class Program
    {
        static void Main(string[] args)
        {
            Planet venus = new("Венера", 2, 38_025);
            Planet earth = new("Земля", 3, 40_075, venus);
            Planet mars = new("Марс", 4, 21_344, earth);
            CatalogOfPlanets catalogOfPlanets = new(venus, earth, mars);
            
            var a = catalogOfPlanets.ToGetAplanet("Земля", PlanetCheck.planetValidator,PlanetCheck.searchForTheForbiddenPlanet);
            var b = catalogOfPlanets.ToGetAplanet("Лимония", PlanetCheck.planetValidator,PlanetCheck.searchForTheForbiddenPlanet);
            var c = catalogOfPlanets.ToGetAplanet("Марс", PlanetCheck.planetValidator,PlanetCheck.searchForTheForbiddenPlanet);

            Tuple<int, int, string>[] tuples = new Tuple<int, int, string>[] { a, b, c };
            foreach (var tuple in tuples)
            {
                if (tuple.Item1 != 0)
                {
                    Console.WriteLine($"Порядковый номер от Солнца: {tuple.Item1}, Длина экватора: {tuple.Item2}, Название планеты: {tuple.Item3}");
                }
                else
                {
                    Console.WriteLine(tuple.Item3);
                }
            }
        }
    }
}