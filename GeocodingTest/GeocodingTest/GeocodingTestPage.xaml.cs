using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using System.Linq;
using System;

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
			sb.AppendFormat("Results @ {0}\n\n", DateTime.Now.ToString());
			sb.AppendFormat("{0} Results\n\n", geoPositions.Count());

			foreach (Position geoPosition in geoPositions)
			{
				sb.AppendFormat("Lat: {0}\nLon: {1}\n\n", geoPosition.Latitude, geoPosition.Longitude);
				Pin mapPin = new Pin()
				{
					Position = geoPosition
				};
			}

			Results.FormattedText = sb.ToString();
		}

	}
}

