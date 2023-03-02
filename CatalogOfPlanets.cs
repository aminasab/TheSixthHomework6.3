namespace TheSixthProgram3._1
{
    internal class CatalogOfPlanets
    {
        private List<Planet> listOfPlanets = new List<Planet>();

        public CatalogOfPlanets(params Planet[] planets)
        {
            listOfPlanets.AddRange(planets);
        }

        /// <summary>
        /// Метод, который производит поиск планеты.
        /// </summary>
        /// <param name="name">Входящее название планеты.</param>
        /// <param name="validator">Делегат, проверяющий количество вызовов метода.</param>
        public Tuple<int, int, string> ToGetAplanet(string name, PlanetValidator validator, PlanetValidator searchForTheForbiddenPlanet)
        {
            var r1 = listOfPlanets.FirstOrDefault(m => m.SerialNumberFromTheSun == 0 && m.LengthOfEquator == 0 && m.Name == name);
            var r2 = listOfPlanets.Select(m => m.Name).Contains(name);

            var validatorResult=validator(name);
            if (validatorResult.Item3.Length != 0)
            {
                return validatorResult;
            }
            
            var searchPlanetResult=searchForTheForbiddenPlanet(name);
            if(searchPlanetResult.Item3.Length != 0)
            {
                return searchPlanetResult;
            }

            if (r1 != null || !r2)
            {
                var result = Tuple.Create(0, 0, "Планета не найдена!");
                return result;
            }
            else
            {
                var result = from m in listOfPlanets where m.Name == name select new Tuple<int, int, string>(m.SerialNumberFromTheSun, m.LengthOfEquator, m.Name);
                return result.FirstOrDefault();
            }
        }

    }
}
