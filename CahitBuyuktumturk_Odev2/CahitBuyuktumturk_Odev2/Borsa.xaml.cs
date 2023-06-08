
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace CahitBuyuktumturk_Odev2;

public partial class Borsa : ContentPage
{
	public Borsa()
	{
		InitializeComponent();
	}
	private static Borsa kopya;
	public static Borsa Page 
	{
		get
		{
			if(kopya== null)
				kopya = new Borsa();
			return kopya;

			
		}
	}
	BorsaDurum borsa;
	protected async override void OnAppearing()
	{
		base.OnAppearing();
		await Load();
	}

	async Task Load()
	{
		string jsondata = await GetGuncel();

		borsa = JsonSerializer.Deserialize<BorsaDurum>(jsondata);
		Sepet.ItemsSource = new List<Doviz>()
		{
		 new Doviz()
		 { D�zizismi="ABD Dolar� ", D�vizAlis=borsa.Dolar.alis, D�vizSatis=borsa.Dolar.satis,
			 Fark=borsa.Dolar.degisim, Durum=Statement(borsa.Dolar.d_yon),},
		 new Doviz()
		 { D�zizismi="Euro-Avro ", D�vizAlis=borsa.Euro.alis, D�vizSatis=borsa.Euro.satis,
			 Fark=borsa.Euro.degisim, Durum=Statement(borsa.Euro.d_yon),},
		  new Doviz()
		 { D�zizismi="Sterlin-Pound ", D�vizAlis=borsa.Sterlin.alis, D�vizSatis=borsa.Sterlin.satis,
			 Fark=borsa.Sterlin.degisim, Durum=Statement(borsa.Sterlin.d_yon),},
		  new Doviz()
		 { D�zizismi="Gram Alt�n ", D�vizAlis=borsa.Alt�nGram.alis, D�vizSatis=borsa.Alt�nGram.satis,
			 Fark=borsa.Alt�nGram.degisim, Durum=Statement(borsa.Alt�nGram.d_yon),},
		};
	}

	private string Statement(string str)
	{
		if (str.Contains("up"))
			return "redarrow.png";
		if (str.Contains("down"))
			return "greenarrow.png";
		if (str.Contains("minus"))
			return "stable.png";
		return "";
		
	}

	async Task<string> GetGuncel()
	{
		HttpClient client = new HttpClient();
		string url = "https://api.genelpara.com/embed/altin.json";
		
		using HttpResponseMessage response = await client.GetAsync(url);
		response.EnsureSuccessStatusCode();

		string jsondata=await response.Content.ReadAsStringAsync();
		return jsondata;
	}
}
public class Doviz
{
	public string D�zizismi { get; set; }
	public string D�vizAlis { get; set; }
	public string D�vizSatis { get; set; }
	public string Fark { get;set; }
	public string Durum { get; set; }

}
public class BorsaDurum
{
	public USD Dolar { get; set; }
	public EUR Euro { get; set; }
	public GBP Sterlin { get; set; }
	public GA Alt�nGram { get; set; }
	public C C { get; set; }
	public GAG G�m�� { get; set; }
	public BTC Bitcoin { get; set; }
	public ETH Ether { get; set; }
	public XU100 Borsa�stanbul { get; set; }
}
public class BTC
{
	public string satis { get; set; }
	public string alis { get; set; }
	public string degisim { get; set; }
	public string d_oran { get; set; }
	public string d_yon { get; set; }
}

public class C
{
	public string satis { get; set; }
	public string alis { get; set; }
	public string degisim { get; set; }
	public string d_oran { get; set; }
	public string d_yon { get; set; }
}

public class ETH
{
	public string satis { get; set; }
	public string alis { get; set; }
	public string degisim { get; set; }
	public string d_oran { get; set; }
	public string d_yon { get; set; }
}

public class EUR
{
	public string satis { get; set; }
	public string alis { get; set; }
	public string degisim { get; set; }
	public string d_oran { get; set; }
	public string d_yon { get; set; }
}

public class GA
{
	public string satis { get; set; }
	public string alis { get; set; }
	public string degisim { get; set; }
	public string d_oran { get; set; }
	public string d_yon { get; set; }
}

public class GAG
{
	public string satis { get; set; }
	public string alis { get; set; }
	public string degisim { get; set; }
	public string d_oran { get; set; }
	public string d_yon { get; set; }
}

public class GBP
{
	public string satis { get; set; }
	public string alis { get; set; }
	public string degisim { get; set; }
	public string d_oran { get; set; }
	public string d_yon { get; set; }
}



public class USD
{
	public string satis { get; set; }
	public string alis { get; set; }
	public string degisim { get; set; }
	public string d_oran { get; set; }
	public string d_yon { get; set; }
}

public class XU100
{
	public string satis { get; set; }
	public string alis { get; set; }
	public string degisim { get; set; }
}

