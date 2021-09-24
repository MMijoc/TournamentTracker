using System.Collections.Generic;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
	public partial class CreateTeamForm : Form
	{
		private List<PersonModel> availabelTeamMemebers = GlobalConfig.Connection.GetPerson_All();
		private List<PersonModel> selectedTeamMemebers = new List<PersonModel>();

		public CreateTeamForm()
		{
			InitializeComponent();

			//CreateSampleData();
			WireUpLists();
		}

		private void CreateSampleData()
		{
			availabelTeamMemebers.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
			availabelTeamMemebers.Add(new PersonModel { FirstName = "Sue", LastName = "Storm" });

			selectedTeamMemebers.Add(new PersonModel { FirstName = "Jane", LastName = "Smith" });
			selectedTeamMemebers.Add(new PersonModel { FirstName = "Bill", LastName = "Jones" });
		}

		//Delete later
		private void WireUpLists()
		{
			selectTeamMemberDropdown.DataSource = null;
			selectTeamMemberDropdown.DataSource = availabelTeamMemebers;
			selectTeamMemberDropdown.DisplayMember = "FullName";

			teamMembersListBox.DataSource = null;
			teamMembersListBox.DataSource = selectedTeamMemebers;
			teamMembersListBox.DisplayMember = "FullName";

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

				model = GlobalConfig.Connection.CreatePerson(model);

				selectedTeamMemebers.Add(model);
				WireUpLists();

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

		private void AddMemberButton_Click(object sender, System.EventArgs e)
		{
			PersonModel model = (PersonModel)selectTeamMemberDropdown.SelectedItem;
			if (model != null)
			{
				availabelTeamMemebers.Remove(model);
				selectedTeamMemebers.Add(model); 
			}

			WireUpLists();
		}

		private void RemoveSelectedTeamMemeberButton_Click(object sender, System.EventArgs e)
		{
			PersonModel model = (PersonModel)teamMembersListBox.SelectedItem;
			if (model != null)
			{
				selectedTeamMemebers.Remove(model);
				availabelTeamMemebers.Add(model);
			}

			WireUpLists();
		}
	}
}
