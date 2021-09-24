
namespace TrackerUI
{
	partial class CreateTeamForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTeamForm));
			this.teamNameValue = new System.Windows.Forms.TextBox();
			this.teamNameLabel = new System.Windows.Forms.Label();
			this.createTeamLabel = new System.Windows.Forms.Label();
			this.addMemberButton = new System.Windows.Forms.Button();
			this.selectTeamMemberDropdown = new System.Windows.Forms.ComboBox();
			this.selectTeamMemberLabel = new System.Windows.Forms.Label();
			this.addNewMemeberGroupBox = new System.Windows.Forms.GroupBox();
			this.createMemberButton = new System.Windows.Forms.Button();
			this.cellPhoneNumberValue = new System.Windows.Forms.TextBox();
			this.cellphoneNumberLabel = new System.Windows.Forms.Label();
			this.emailValue = new System.Windows.Forms.TextBox();
			this.emailLabel = new System.Windows.Forms.Label();
			this.lastNameValue = new System.Windows.Forms.TextBox();
			this.lastNameLabel = new System.Windows.Forms.Label();
			this.firstNameValue = new System.Windows.Forms.TextBox();
			this.firstNameLabel = new System.Windows.Forms.Label();
			this.teamMembersListBox = new System.Windows.Forms.ListBox();
			this.removeSelectedTeamMemeberButton = new System.Windows.Forms.Button();
			this.createTeamButton = new System.Windows.Forms.Button();
			this.addNewMemeberGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// teamNameValue
			// 
			this.teamNameValue.Location = new System.Drawing.Point(19, 121);
			this.teamNameValue.Name = "teamNameValue";
			this.teamNameValue.Size = new System.Drawing.Size(440, 43);
			this.teamNameValue.TabIndex = 13;
			// 
			// teamNameLabel
			// 
			this.teamNameLabel.AutoSize = true;
			this.teamNameLabel.ForeColor = System.Drawing.Color.Blue;
			this.teamNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.teamNameLabel.Location = new System.Drawing.Point(19, 74);
			this.teamNameLabel.Name = "teamNameLabel";
			this.teamNameLabel.Size = new System.Drawing.Size(164, 38);
			this.teamNameLabel.TabIndex = 12;
			this.teamNameLabel.Text = "Team Name";
			// 
			// createTeamLabel
			// 
			this.createTeamLabel.AutoSize = true;
			this.createTeamLabel.Font = new System.Drawing.Font("Segoe UI Light", 28.2F);
			this.createTeamLabel.ForeColor = System.Drawing.Color.Blue;
			this.createTeamLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.createTeamLabel.Location = new System.Drawing.Point(15, 9);
			this.createTeamLabel.Name = "createTeamLabel";
			this.createTeamLabel.Size = new System.Drawing.Size(276, 65);
			this.createTeamLabel.TabIndex = 11;
			this.createTeamLabel.Text = "Create Team";
			// 
			// addMemberButton
			// 
			this.addMemberButton.BackColor = System.Drawing.Color.White;
			this.addMemberButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.addMemberButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.addMemberButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			this.addMemberButton.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold);
			this.addMemberButton.ForeColor = System.Drawing.Color.Blue;
			this.addMemberButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.addMemberButton.Location = new System.Drawing.Point(116, 277);
			this.addMemberButton.Name = "addMemberButton";
			this.addMemberButton.Size = new System.Drawing.Size(238, 58);
			this.addMemberButton.TabIndex = 19;
			this.addMemberButton.Text = "Add Member";
			this.addMemberButton.UseVisualStyleBackColor = false;
			this.addMemberButton.Click += new System.EventHandler(this.AddMemberButton_Click);
			// 
			// selectTeamMemberDropdown
			// 
			this.selectTeamMemberDropdown.ForeColor = System.Drawing.Color.Blue;
			this.selectTeamMemberDropdown.FormattingEnabled = true;
			this.selectTeamMemberDropdown.Location = new System.Drawing.Point(19, 226);
			this.selectTeamMemberDropdown.Name = "selectTeamMemberDropdown";
			this.selectTeamMemberDropdown.Size = new System.Drawing.Size(440, 45);
			this.selectTeamMemberDropdown.TabIndex = 18;
			// 
			// selectTeamMemberLabel
			// 
			this.selectTeamMemberLabel.AutoSize = true;
			this.selectTeamMemberLabel.ForeColor = System.Drawing.Color.Blue;
			this.selectTeamMemberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.selectTeamMemberLabel.Location = new System.Drawing.Point(19, 185);
			this.selectTeamMemberLabel.Name = "selectTeamMemberLabel";
			this.selectTeamMemberLabel.Size = new System.Drawing.Size(277, 38);
			this.selectTeamMemberLabel.TabIndex = 17;
			this.selectTeamMemberLabel.Text = "Select Team Member";
			// 
			// addNewMemeberGroupBox
			// 
			this.addNewMemeberGroupBox.Controls.Add(this.createMemberButton);
			this.addNewMemeberGroupBox.Controls.Add(this.cellPhoneNumberValue);
			this.addNewMemeberGroupBox.Controls.Add(this.cellphoneNumberLabel);
			this.addNewMemeberGroupBox.Controls.Add(this.emailValue);
			this.addNewMemeberGroupBox.Controls.Add(this.emailLabel);
			this.addNewMemeberGroupBox.Controls.Add(this.lastNameValue);
			this.addNewMemeberGroupBox.Controls.Add(this.lastNameLabel);
			this.addNewMemeberGroupBox.Controls.Add(this.firstNameValue);
			this.addNewMemeberGroupBox.Controls.Add(this.firstNameLabel);
			this.addNewMemeberGroupBox.Location = new System.Drawing.Point(19, 352);
			this.addNewMemeberGroupBox.Name = "addNewMemeberGroupBox";
			this.addNewMemeberGroupBox.Size = new System.Drawing.Size(440, 390);
			this.addNewMemeberGroupBox.TabIndex = 20;
			this.addNewMemeberGroupBox.TabStop = false;
			this.addNewMemeberGroupBox.Text = "Add New Member";
			// 
			// createMemberButton
			// 
			this.createMemberButton.BackColor = System.Drawing.Color.White;
			this.createMemberButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.createMemberButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.createMemberButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			this.createMemberButton.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold);
			this.createMemberButton.ForeColor = System.Drawing.Color.Blue;
			this.createMemberButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.createMemberButton.Location = new System.Drawing.Point(88, 326);
			this.createMemberButton.Name = "createMemberButton";
			this.createMemberButton.Size = new System.Drawing.Size(273, 58);
			this.createMemberButton.TabIndex = 20;
			this.createMemberButton.Text = "Create Member";
			this.createMemberButton.UseVisualStyleBackColor = false;
			this.createMemberButton.Click += new System.EventHandler(this.CreateMemberButton_Click);
			// 
			// cellPhoneNumberValue
			// 
			this.cellPhoneNumberValue.Location = new System.Drawing.Point(191, 251);
			this.cellPhoneNumberValue.Name = "cellPhoneNumberValue";
			this.cellPhoneNumberValue.Size = new System.Drawing.Size(220, 43);
			this.cellPhoneNumberValue.TabIndex = 16;
			// 
			// cellphoneNumberLabel
			// 
			this.cellphoneNumberLabel.AutoSize = true;
			this.cellphoneNumberLabel.ForeColor = System.Drawing.Color.Blue;
			this.cellphoneNumberLabel.Location = new System.Drawing.Point(32, 253);
			this.cellphoneNumberLabel.Name = "cellphoneNumberLabel";
			this.cellphoneNumberLabel.Size = new System.Drawing.Size(142, 38);
			this.cellphoneNumberLabel.TabIndex = 15;
			this.cellphoneNumberLabel.Text = "Cellphone";
			// 
			// emailValue
			// 
			this.emailValue.Location = new System.Drawing.Point(193, 184);
			this.emailValue.Name = "emailValue";
			this.emailValue.Size = new System.Drawing.Size(220, 43);
			this.emailValue.TabIndex = 14;
			// 
			// emailLabel
			// 
			this.emailLabel.AutoSize = true;
			this.emailLabel.ForeColor = System.Drawing.Color.Blue;
			this.emailLabel.Location = new System.Drawing.Point(32, 186);
			this.emailLabel.Name = "emailLabel";
			this.emailLabel.Size = new System.Drawing.Size(83, 38);
			this.emailLabel.TabIndex = 13;
			this.emailLabel.Text = "Email";
			// 
			// lastNameValue
			// 
			this.lastNameValue.Location = new System.Drawing.Point(191, 118);
			this.lastNameValue.Name = "lastNameValue";
			this.lastNameValue.Size = new System.Drawing.Size(220, 43);
			this.lastNameValue.TabIndex = 12;
			// 
			// lastNameLabel
			// 
			this.lastNameLabel.AutoSize = true;
			this.lastNameLabel.ForeColor = System.Drawing.Color.Blue;
			this.lastNameLabel.Location = new System.Drawing.Point(32, 120);
			this.lastNameLabel.Name = "lastNameLabel";
			this.lastNameLabel.Size = new System.Drawing.Size(147, 38);
			this.lastNameLabel.TabIndex = 11;
			this.lastNameLabel.Text = "Last Name";
			// 
			// firstNameValue
			// 
			this.firstNameValue.Location = new System.Drawing.Point(193, 57);
			this.firstNameValue.Name = "firstNameValue";
			this.firstNameValue.Size = new System.Drawing.Size(220, 43);
			this.firstNameValue.TabIndex = 10;
			// 
			// firstNameLabel
			// 
			this.firstNameLabel.AutoSize = true;
			this.firstNameLabel.ForeColor = System.Drawing.Color.Blue;
			this.firstNameLabel.Location = new System.Drawing.Point(32, 59);
			this.firstNameLabel.Name = "firstNameLabel";
			this.firstNameLabel.Size = new System.Drawing.Size(151, 38);
			this.firstNameLabel.TabIndex = 9;
			this.firstNameLabel.Text = "First Name";
			// 
			// teamMembersListBox
			// 
			this.teamMembersListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.teamMembersListBox.FormattingEnabled = true;
			this.teamMembersListBox.ItemHeight = 37;
			this.teamMembersListBox.Location = new System.Drawing.Point(540, 121);
			this.teamMembersListBox.Name = "teamMembersListBox";
			this.teamMembersListBox.Size = new System.Drawing.Size(423, 520);
			this.teamMembersListBox.TabIndex = 21;
			// 
			// removeSelectedTeamMemeberButton
			// 
			this.removeSelectedTeamMemeberButton.BackColor = System.Drawing.Color.White;
			this.removeSelectedTeamMemeberButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.removeSelectedTeamMemeberButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.removeSelectedTeamMemeberButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			this.removeSelectedTeamMemeberButton.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold);
			this.removeSelectedTeamMemeberButton.ForeColor = System.Drawing.Color.Blue;
			this.removeSelectedTeamMemeberButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.removeSelectedTeamMemeberButton.Location = new System.Drawing.Point(984, 168);
			this.removeSelectedTeamMemeberButton.Name = "removeSelectedTeamMemeberButton";
			this.removeSelectedTeamMemeberButton.Size = new System.Drawing.Size(243, 71);
			this.removeSelectedTeamMemeberButton.TabIndex = 24;
			this.removeSelectedTeamMemeberButton.Text = "Remove Selected";
			this.removeSelectedTeamMemeberButton.UseVisualStyleBackColor = false;
			this.removeSelectedTeamMemeberButton.Click += new System.EventHandler(this.RemoveSelectedTeamMemeberButton_Click);
			// 
			// createTeamButton
			// 
			this.createTeamButton.BackColor = System.Drawing.Color.White;
			this.createTeamButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.createTeamButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.createTeamButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			this.createTeamButton.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold);
			this.createTeamButton.ForeColor = System.Drawing.Color.Blue;
			this.createTeamButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.createTeamButton.Location = new System.Drawing.Point(540, 670);
			this.createTeamButton.Name = "createTeamButton";
			this.createTeamButton.Size = new System.Drawing.Size(423, 72);
			this.createTeamButton.TabIndex = 25;
			this.createTeamButton.Text = "Create Team";
			this.createTeamButton.UseVisualStyleBackColor = false;
			this.createTeamButton.Click += new System.EventHandler(this.CreateTeamButton_Click);
			// 
			// CreateTeamForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1246, 778);
			this.Controls.Add(this.createTeamButton);
			this.Controls.Add(this.removeSelectedTeamMemeberButton);
			this.Controls.Add(this.teamMembersListBox);
			this.Controls.Add(this.addNewMemeberGroupBox);
			this.Controls.Add(this.addMemberButton);
			this.Controls.Add(this.selectTeamMemberDropdown);
			this.Controls.Add(this.selectTeamMemberLabel);
			this.Controls.Add(this.teamNameValue);
			this.Controls.Add(this.teamNameLabel);
			this.Controls.Add(this.createTeamLabel);
			this.Font = new System.Drawing.Font("Segoe UI", 16.2F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "CreateTeamForm";
			this.Text = "Create Team";
			this.addNewMemeberGroupBox.ResumeLayout(false);
			this.addNewMemeberGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox teamNameValue;
		private System.Windows.Forms.Label teamNameLabel;
		private System.Windows.Forms.Label createTeamLabel;
		private System.Windows.Forms.Button addMemberButton;
		private System.Windows.Forms.ComboBox selectTeamMemberDropdown;
		private System.Windows.Forms.Label selectTeamMemberLabel;
		private System.Windows.Forms.GroupBox addNewMemeberGroupBox;
		private System.Windows.Forms.Button createMemberButton;
		private System.Windows.Forms.TextBox cellPhoneNumberValue;
		private System.Windows.Forms.Label cellphoneNumberLabel;
		private System.Windows.Forms.TextBox emailValue;
		private System.Windows.Forms.Label emailLabel;
		private System.Windows.Forms.TextBox lastNameValue;
		private System.Windows.Forms.Label lastNameLabel;
		private System.Windows.Forms.TextBox firstNameValue;
		private System.Windows.Forms.Label firstNameLabel;
		private System.Windows.Forms.ListBox teamMembersListBox;
		private System.Windows.Forms.Button removeSelectedTeamMemeberButton;
		private System.Windows.Forms.Button createTeamButton;
	}
}