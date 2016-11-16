using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using System.Linq;


namespace GeocodingTest
{
	public partial class GeocodingTestPage : ContentPage
	{
		public GeocodingTestPage()
		{
			InitializeComponent();
		}

		async void Handle_GeocodeClick(object sender, System.EventArgs e)
		{
			Geocoder geocoder = new Geocoder();

			IEnumerable<Position> geoPositions = await geocoder.GetPositionsForAddressAsync(string.Format("{0}, {1}, {2}", Address.Text, City.Text, State.Text));
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("{0} Results\n", geoPositions.Count());

			foreach (Position geoPosition in geoPositions)
			{
				sb.AppendFormat("Lat: {0} / Lon: {1}\n", geoPosition.Latitude, geoPosition.Longitude);
				Pin mapPin = new Pin()
				{
					Position = geoPosition
				};
				MapResult.Pins.Add(mapPin);
			}

			Results.FormattedText = sb.ToString();
		}

	}
}

