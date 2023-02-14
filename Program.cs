public class WeatherService
{
	private List<string> InformacoesTempo { get; set; }

	public WeatherService()
	{
		InformacoesTempo = new List<string>();
	}

	public async Task<List<string>> GetWheatherAsync(List<string> listaCidades)
	{
		Console.WriteLine("Requisitando informações do tempo...");

		InformacoesTempo.Clear();

		foreach(string cidade in listaCidades)
		{
			switch (cidade)
			{
				case "São Paulo":
					InformacoesTempo.Add("Frio e chuvoso");
					break;
				case "Rio de Janeiro":
				    InformacoesTempo.Add("Quente e ensolarado");
				    break;
				case "Brasília":
				    InformacoesTempo.Add("Quente e nublado");
				    break;
				case "Manaus":
				    InformacoesTempo.Add("Quente e chuvoso");
				    break;
				case "Porto Alegre":
				    InformacoesTempo.Add("Frio e ensolarado");
				    break;
				case "Belo Horizonte":
				    InformacoesTempo.Add("Frio e nublado");
				    break;
			    }
            	await Task.Delay(1000);
        }

		Console.WriteLine("Requisição completa!");
		return InformacoesTempo;
	}
}

public class CityListReader
{
    private List<string> ListaCidades { get; set; }

	public CityListReader()
	{
		ListaCidades = new List<string>();
	}

	public async Task<List<string>> ReadCityListAsync()
	{
		Console.WriteLine("Lendo o arquivo...");

		ListaCidades.Clear();
		ListaCidades.Add("São Paulo");
		ListaCidades.Add("Rio de Janeiro");
		ListaCidades.Add("Brasília");
		ListaCidades.Add("Manaus");
		ListaCidades.Add("Porto Alegre");
        	ListaCidades.Add("Belo Horizonte");

		await Task.Delay(3000);
        	Console.WriteLine("Leitura completa!");
		return ListaCidades;
	}
}

internal class Program
{
	static async Task Main(string[] args)
	{
		var reader = new CityListReader();
		var service = new WeatherService();

		Task <List<string>> task1 = reader.ReadCityListAsync();
		List<string> listaCidades = await task1;

		Task<List<string>> task2 = service.GetWheatherAsync(listaCidades);
		List<string> informacoesTempo = await task2;

		Task.WhenAll(task1, task2).Wait();

		for(int i = 0; i < listaCidades.Count; i++)
			Console.WriteLine($"Clima de {listaCidades[i]}: {informacoesTempo[i]}");
	}
}
