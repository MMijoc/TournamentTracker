using System;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
	public partial class CreatePrizeForm : Form
	{
		public CreatePrizeForm()
		{
			InitializeComponent();
		}

		private void CreatePrizeButton_Click(object sender, EventArgs e)
		{
			if (ValidateForm() == true)
			{
				var model = new PrizeModel(
					placeNumberValue.Text,
					placeNameValue.Text,
					prizeAmountValue.Text,
					prizePercentageValue.Text);

				GlobalConfig.Connection.CreatePrize(model);

				placeNumberValue.Text = "";
				placeNameValue.Text = "";
				prizeAmountValue.Text = "0";
				prizePercentageValue.Text = "0";
			}
			else
			{
				MessageBox.Show("This form has invalid information. Please check it and try again.");
			}
		}

		private bool ValidateForm()
		{
			var output = true;

			var placeNumberValidNumber = int.TryParse(placeNumberValue.Text, out int placeNumber);
			if (placeNumberValidNumber == false)
			{
				output = false;
			}
			
			if (placeNumber < 1)
			{
				output = false;
			}

			if(placeNameValue.Text.Length == 0)
			{
				output = false;
			}



			var prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out decimal prizeAmount);
			var prizePercentageValid = double.TryParse(prizePercentageValue.Text, out double prizePercentage);

			if (prizeAmountValid == false || prizePercentageValid == false)
			{
				output = false;
			}

			if (prizeAmount <= 0 && prizePercentage <= 0)
			{
				output = false;
			}

			if (prizePercentage < 0 || prizePercentage > 100)
			{
				output = false;
			}

			return output;
		}
	}
}
