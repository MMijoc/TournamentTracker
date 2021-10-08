using System;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;
using TrackerUIFrame;

namespace TrackerUI
{
	public partial class CreatePrizeForm : Form
	{
		IPrizeRequester callingForm;
		public CreatePrizeForm(IPrizeRequester caller)
		{
			InitializeComponent();

			callingForm = caller;
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

				model = GlobalConfig.Connection.CreatePrize(model);
				callingForm.PrizeComplete(model);

				this.Close();
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
