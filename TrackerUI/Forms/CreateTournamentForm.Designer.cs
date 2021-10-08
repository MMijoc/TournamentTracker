
namespace TrackerUI
{
	partial class CreateTournamentForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTournamentForm));
			this.createTournamentLabel = new System.Windows.Forms.Label();
			this.tournamentNameValue = new System.Windows.Forms.TextBox();
			this.tournamentNameLabel = new System.Windows.Forms.Label();
			this.entryFeeValue = new System.Windows.Forms.TextBox();
			this.entryFeeLabel = new System.Windows.Forms.Label();
			this.selectTeamDropdown = new System.Windows.Forms.ComboBox();
			this.selectTeamLabel = new System.Windows.Forms.Label();
			this.createNewTeamLink = new System.Windows.Forms.LinkLabel();
			this.addTeamButton = new System.Windows.Forms.Button();
			this.createPrizeButton = new System.Windows.Forms.Button();
			this.tournamentTeamsListBox = new System.Windows.Forms.ListBox();
			this.tournamentPlayersLabel = new System.Windows.Forms.Label();
			this.removeSelectedPlayerButton = new System.Windows.Forms.Button();
			this.removeSelectedPrizeButton = new System.Windows.Forms.Button();
			this.prizesLabel = new System.Windows.Forms.Label();
			this.prizesListBox = new System.Windows.Forms.ListBox();
			this.createTournamentButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// createTournamentLabel
			// 
			resources.ApplyResources(this.createTournamentLabel, "createTournamentLabel");
			this.createTournamentLabel.ForeColor = System.Drawing.Color.Blue;
			this.createTournamentLabel.Name = "createTournamentLabel";
			// 
			// tournamentNameValue
			// 
			resources.ApplyResources(this.tournamentNameValue, "tournamentNameValue");
			this.tournamentNameValue.Name = "tournamentNameValue";
			// 
			// tournamentNameLabel
			// 
			resources.ApplyResources(this.tournamentNameLabel, "tournamentNameLabel");
			this.tournamentNameLabel.ForeColor = System.Drawing.Color.Blue;
			this.tournamentNameLabel.Name = "tournamentNameLabel";
			// 
			// entryFeeValue
			// 
			resources.ApplyResources(this.entryFeeValue, "entryFeeValue");
			this.entryFeeValue.Name = "entryFeeValue";
			// 
			// entryFeeLabel
			// 
			resources.ApplyResources(this.entryFeeLabel, "entryFeeLabel");
			this.entryFeeLabel.ForeColor = System.Drawing.Color.Blue;
			this.entryFeeLabel.Name = "entryFeeLabel";
			// 
			// selectTeamDropdown
			// 
			this.selectTeamDropdown.ForeColor = System.Drawing.Color.Blue;
			this.selectTeamDropdown.FormattingEnabled = true;
			resources.ApplyResources(this.selectTeamDropdown, "selectTeamDropdown");
			this.selectTeamDropdown.Name = "selectTeamDropdown";
			// 
			// selectTeamLabel
			// 
			resources.ApplyResources(this.selectTeamLabel, "selectTeamLabel");
			this.selectTeamLabel.ForeColor = System.Drawing.Color.Blue;
			this.selectTeamLabel.Name = "selectTeamLabel";
			// 
			// createNewTeamLink
			// 
			resources.ApplyResources(this.createNewTeamLink, "createNewTeamLink");
			this.createNewTeamLink.Name = "createNewTeamLink";
			this.createNewTeamLink.TabStop = true;
			this.createNewTeamLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreateNewTeamLink_LinkClicked);
			// 
			// addTeamButton
			// 
			this.addTeamButton.BackColor = System.Drawing.Color.White;
			this.addTeamButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.addTeamButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.addTeamButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			resources.ApplyResources(this.addTeamButton, "addTeamButton");
			this.addTeamButton.ForeColor = System.Drawing.Color.Blue;
			this.addTeamButton.Name = "addTeamButton";
			this.addTeamButton.UseVisualStyleBackColor = false;
			this.addTeamButton.Click += new System.EventHandler(this.AddTeamButton_Click);
			// 
			// createPrizeButton
			// 
			this.createPrizeButton.BackColor = System.Drawing.Color.White;
			this.createPrizeButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.createPrizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.createPrizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			resources.ApplyResources(this.createPrizeButton, "createPrizeButton");
			this.createPrizeButton.ForeColor = System.Drawing.Color.Blue;
			this.createPrizeButton.Name = "createPrizeButton";
			this.createPrizeButton.UseVisualStyleBackColor = false;
			this.createPrizeButton.Click += new System.EventHandler(this.CreatePrizeButton_Click);
			// 
			// tournamentTeamsListBox
			// 
			this.tournamentTeamsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tournamentTeamsListBox.FormattingEnabled = true;
			resources.ApplyResources(this.tournamentTeamsListBox, "tournamentTeamsListBox");
			this.tournamentTeamsListBox.Name = "tournamentTeamsListBox";
			// 
			// tournamentPlayersLabel
			// 
			resources.ApplyResources(this.tournamentPlayersLabel, "tournamentPlayersLabel");
			this.tournamentPlayersLabel.ForeColor = System.Drawing.Color.Blue;
			this.tournamentPlayersLabel.Name = "tournamentPlayersLabel";
			// 
			// removeSelectedPlayerButton
			// 
			this.removeSelectedPlayerButton.BackColor = System.Drawing.Color.White;
			this.removeSelectedPlayerButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.removeSelectedPlayerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.removeSelectedPlayerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			resources.ApplyResources(this.removeSelectedPlayerButton, "removeSelectedPlayerButton");
			this.removeSelectedPlayerButton.ForeColor = System.Drawing.Color.Blue;
			this.removeSelectedPlayerButton.Name = "removeSelectedPlayerButton";
			this.removeSelectedPlayerButton.UseVisualStyleBackColor = false;
			this.removeSelectedPlayerButton.Click += new System.EventHandler(this.RemoveSelectedPlayerButton_Click);
			// 
			// removeSelectedPrizeButton
			// 
			this.removeSelectedPrizeButton.BackColor = System.Drawing.Color.White;
			this.removeSelectedPrizeButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.removeSelectedPrizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.removeSelectedPrizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			resources.ApplyResources(this.removeSelectedPrizeButton, "removeSelectedPrizeButton");
			this.removeSelectedPrizeButton.ForeColor = System.Drawing.Color.Blue;
			this.removeSelectedPrizeButton.Name = "removeSelectedPrizeButton";
			this.removeSelectedPrizeButton.UseVisualStyleBackColor = false;
			this.removeSelectedPrizeButton.Click += new System.EventHandler(this.RemoveSelectedPrizeButton_Click);
			// 
			// prizesLabel
			// 
			resources.ApplyResources(this.prizesLabel, "prizesLabel");
			this.prizesLabel.ForeColor = System.Drawing.Color.Blue;
			this.prizesLabel.Name = "prizesLabel";
			// 
			// prizesListBox
			// 
			this.prizesListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.prizesListBox.FormattingEnabled = true;
			resources.ApplyResources(this.prizesListBox, "prizesListBox");
			this.prizesListBox.Name = "prizesListBox";
			// 
			// createTournamentButton
			// 
			this.createTournamentButton.BackColor = System.Drawing.Color.White;
			this.createTournamentButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.createTournamentButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.createTournamentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			resources.ApplyResources(this.createTournamentButton, "createTournamentButton");
			this.createTournamentButton.ForeColor = System.Drawing.Color.Blue;
			this.createTournamentButton.Name = "createTournamentButton";
			this.createTournamentButton.UseVisualStyleBackColor = false;
			// 
			// CreateTournamentForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.createTournamentButton);
			this.Controls.Add(this.removeSelectedPrizeButton);
			this.Controls.Add(this.prizesLabel);
			this.Controls.Add(this.prizesListBox);
			this.Controls.Add(this.removeSelectedPlayerButton);
			this.Controls.Add(this.tournamentPlayersLabel);
			this.Controls.Add(this.tournamentTeamsListBox);
			this.Controls.Add(this.createPrizeButton);
			this.Controls.Add(this.addTeamButton);
			this.Controls.Add(this.createNewTeamLink);
			this.Controls.Add(this.selectTeamDropdown);
			this.Controls.Add(this.selectTeamLabel);
			this.Controls.Add(this.entryFeeValue);
			this.Controls.Add(this.entryFeeLabel);
			this.Controls.Add(this.tournamentNameValue);
			this.Controls.Add(this.tournamentNameLabel);
			this.Controls.Add(this.createTournamentLabel);
			this.Name = "CreateTournamentForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label createTournamentLabel;
		private System.Windows.Forms.TextBox tournamentNameValue;
		private System.Windows.Forms.Label tournamentNameLabel;
		private System.Windows.Forms.TextBox entryFeeValue;
		private System.Windows.Forms.Label entryFeeLabel;
		private System.Windows.Forms.ComboBox selectTeamDropdown;
		private System.Windows.Forms.Label selectTeamLabel;
		private System.Windows.Forms.LinkLabel createNewTeamLink;
		private System.Windows.Forms.Button addTeamButton;
		private System.Windows.Forms.Button createPrizeButton;
		private System.Windows.Forms.ListBox tournamentTeamsListBox;
		private System.Windows.Forms.Label tournamentPlayersLabel;
		private System.Windows.Forms.Button removeSelectedPlayerButton;
		private System.Windows.Forms.Button removeSelectedPrizeButton;
		private System.Windows.Forms.Label prizesLabel;
		private System.Windows.Forms.ListBox prizesListBox;
		private System.Windows.Forms.Button createTournamentButton;
	}
}