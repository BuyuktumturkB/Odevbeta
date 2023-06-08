
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
		 { Dözizismi="ABD Dolarý ", DövizAlis=borsa.Dolar.alis, DövizSatis=borsa.Dolar.satis,
			 Fark=borsa.Dolar.degisim, Durum=Statement(borsa.Dolar.d_yon),},
		 new Doviz()
		 { Dözizismi="Euro-Avro ", DövizAlis=borsa.Euro.alis, DövizSatis=borsa.Euro.satis,
			 Fark=borsa.Euro.degisim, Durum=Statement(borsa.Euro.d_yon),},
		  new Doviz()
		 { Dözizismi="Sterlin-Pound ", DövizAlis=borsa.Sterlin.alis, DövizSatis=borsa.Sterlin.satis,
			 Fark=borsa.Sterlin.degisim, Durum=Statement(borsa.Sterlin.d_yon),},
		  new Doviz()
		 { Dözizismi="Gram Altýn ", DövizAlis=borsa.AltýnGram.alis, DövizSatis=borsa.AltýnGram.satis,
			 Fark=borsa.AltýnGram.degisim, Durum=Statement(borsa.AltýnGram.d_yon),},
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
	public string Dözizismi { get; set; }
	public string DövizAlis { get; set; }
	public string DövizSatis { get; set; }
	public string Fark { get;set; }
	public string Durum { get; set; }

}
public class BorsaDurum
{
	public USD Dolar { get; set; }
	public EUR Euro { get; set; }
	public GBP Sterlin { get; set; }
	public GA AltýnGram { get; set; }
	public C C { get; set; }
	public GAG Gümüþ { get; set; }
	public BTC Bitcoin { get; set; }
	public ETH Ether { get; set; }
	public XU100 BorsaÝstanbul { get; set; }
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

