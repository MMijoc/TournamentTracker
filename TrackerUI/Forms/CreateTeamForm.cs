using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
	public partial class CreateTeamForm : Form
	{
		public CreateTeamForm()
		{
			InitializeComponent();
		}

		private void CreateMemberButton_Click(object sender, System.EventArgs e)
		{
			if (ValidateForm())
			{
				var model = new PersonModel();

				model.FirstName = firstNameValue.Text;
				model.LastName = lastNameValue.Text;
				model.EmailAddress = emailValue.Text;
				model.CellphoneNumber = cellPhoneNumberValue.Text;

				GlobalConfig.Connection.CreatePerson(model);

				firstNameValue.Text = "";
				lastNameValue.Text = "";
				emailValue.Text = "";
				cellPhoneNumberValue.Text = "";
			}
			else
			{
				MessageBox.Show("You need to fill in all of the fields.");
			}
		}

		private bool ValidateForm()
		{
			if (firstNameValue.Text.Length == 0)
			{
				return false;
			}

			if (lastNameValue.Text.Length == 0)
			{
				return false;
			}

			if (emailValue.Text.Length == 0)
			{
				return false;
			}

			if (cellPhoneNumberValue.Text.Length == 0)
			{
				return false;
			}

			return true;
		}
	}
}
