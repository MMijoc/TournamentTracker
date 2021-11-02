
namespace TrackerUI
{
	partial class TournamentViewerForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentViewerForm));
			this.headerLabel = new System.Windows.Forms.Label();
			this.tournamentName = new System.Windows.Forms.Label();
			this.RoundLabel = new System.Windows.Forms.Label();
			this.roundDropdown = new System.Windows.Forms.ComboBox();
			this.unplayedOnlyCheckbox = new System.Windows.Forms.CheckBox();
			this.matchupListbox = new System.Windows.Forms.ListBox();
			this.teamOneName = new System.Windows.Forms.Label();
			this.teamOneScoreLabel = new System.Windows.Forms.Label();
			this.teamOneScoreValue = new System.Windows.Forms.TextBox();
			this.teamTwoScoreValue = new System.Windows.Forms.TextBox();
			this.teamTwoScoreLabel = new System.Windows.Forms.Label();
			this.teamTwoName = new System.Windows.Forms.Label();
			this.versusLabel = new System.Windows.Forms.Label();
			this.scoreButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// headerLabel
			// 
			this.headerLabel.AutoSize = true;
			this.headerLabel.Font = new System.Drawing.Font("Segoe UI Light", 28.2F);
			this.headerLabel.ForeColor = System.Drawing.Color.Blue;
			this.headerLabel.Location = new System.Drawing.Point(12, 9);
			this.headerLabel.Name = "headerLabel";
			this.headerLabel.Size = new System.Drawing.Size(291, 65);
			this.headerLabel.TabIndex = 0;
			this.headerLabel.Text = "Tournament: ";
			// 
			// tournamentName
			// 
			this.tournamentName.AutoSize = true;
			this.tournamentName.Font = new System.Drawing.Font("Segoe UI Light", 28.2F);
			this.tournamentName.ForeColor = System.Drawing.Color.Blue;
			this.tournamentName.Location = new System.Drawing.Point(270, 9);
			this.tournamentName.Name = "tournamentName";
			this.tournamentName.Size = new System.Drawing.Size(193, 65);
			this.tournamentName.TabIndex = 1;
			this.tournamentName.Text = "<none>";
			// 
			// RoundLabel
			// 
			this.RoundLabel.AutoSize = true;
			this.RoundLabel.ForeColor = System.Drawing.Color.Blue;
			this.RoundLabel.Location = new System.Drawing.Point(44, 99);
			this.RoundLabel.Name = "RoundLabel";
			this.RoundLabel.Size = new System.Drawing.Size(97, 38);
			this.RoundLabel.TabIndex = 2;
			this.RoundLabel.Text = "Round";
			// 
			// roundDropdown
			// 
			this.roundDropdown.ForeColor = System.Drawing.Color.Blue;
			this.roundDropdown.FormattingEnabled = true;
			this.roundDropdown.Location = new System.Drawing.Point(147, 92);
			this.roundDropdown.Name = "roundDropdown";
			this.roundDropdown.Size = new System.Drawing.Size(306, 45);
			this.roundDropdown.TabIndex = 3;
			this.roundDropdown.SelectedIndexChanged += new System.EventHandler(this.RoundDropdown_SelectedIndexChanged);
			// 
			// unplayedOnlyCheckbox
			// 
			this.unplayedOnlyCheckbox.AutoSize = true;
			this.unplayedOnlyCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.unplayedOnlyCheckbox.ForeColor = System.Drawing.Color.Blue;
			this.unplayedOnlyCheckbox.Location = new System.Drawing.Point(147, 152);
			this.unplayedOnlyCheckbox.Name = "unplayedOnlyCheckbox";
			this.unplayedOnlyCheckbox.Size = new System.Drawing.Size(218, 42);
			this.unplayedOnlyCheckbox.TabIndex = 4;
			this.unplayedOnlyCheckbox.Text = "Unplayed Only";
			this.unplayedOnlyCheckbox.UseVisualStyleBackColor = true;
			// 
			// matchupListbox
			// 
			this.matchupListbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.matchupListbox.FormattingEnabled = true;
			this.matchupListbox.ItemHeight = 37;
			this.matchupListbox.Location = new System.Drawing.Point(44, 295);
			this.matchupListbox.Name = "matchupListbox";
			this.matchupListbox.Size = new System.Drawing.Size(409, 372);
			this.matchupListbox.TabIndex = 5;
			this.matchupListbox.SelectedIndexChanged += new System.EventHandler(this.MatchupListbox_SelectedIndexChanged);
			// 
			// teamOneName
			// 
			this.teamOneName.AutoSize = true;
			this.teamOneName.ForeColor = System.Drawing.Color.Blue;
			this.teamOneName.Location = new System.Drawing.Point(538, 324);
			this.teamOneName.Name = "teamOneName";
			this.teamOneName.Size = new System.Drawing.Size(172, 38);
			this.teamOneName.TabIndex = 6;
			this.teamOneName.Text = "<team one>";
			// 
			// teamOneScoreLabel
			// 
			this.teamOneScoreLabel.AutoSize = true;
			this.teamOneScoreLabel.ForeColor = System.Drawing.Color.Blue;
			this.teamOneScoreLabel.Location = new System.Drawing.Point(538, 370);
			this.teamOneScoreLabel.Name = "teamOneScoreLabel";
			this.teamOneScoreLabel.Size = new System.Drawing.Size(86, 38);
			this.teamOneScoreLabel.TabIndex = 7;
			this.teamOneScoreLabel.Text = "Score";
			// 
			// teamOneScoreValue
			// 
			this.teamOneScoreValue.Location = new System.Drawing.Point(630, 367);
			this.teamOneScoreValue.Name = "teamOneScoreValue";
			this.teamOneScoreValue.Size = new System.Drawing.Size(143, 43);
			this.teamOneScoreValue.TabIndex = 8;
			// 
			// teamTwoScoreValue
			// 
			this.teamTwoScoreValue.Location = new System.Drawing.Point(630, 577);
			this.teamTwoScoreValue.Name = "teamTwoScoreValue";
			this.teamTwoScoreValue.Size = new System.Drawing.Size(143, 43);
			this.teamTwoScoreValue.TabIndex = 11;
			// 
			// teamTwoScoreLabel
			// 
			this.teamTwoScoreLabel.AutoSize = true;
			this.teamTwoScoreLabel.ForeColor = System.Drawing.Color.Blue;
			this.teamTwoScoreLabel.Location = new System.Drawing.Point(538, 580);
			this.teamTwoScoreLabel.Name = "teamTwoScoreLabel";
			this.teamTwoScoreLabel.Size = new System.Drawing.Size(86, 38);
			this.teamTwoScoreLabel.TabIndex = 10;
			this.teamTwoScoreLabel.Text = "Score";
			// 
			// teamTwoName
			// 
			this.teamTwoName.AutoSize = true;
			this.teamTwoName.ForeColor = System.Drawing.Color.Blue;
			this.teamTwoName.Location = new System.Drawing.Point(538, 536);
			this.teamTwoName.Name = "teamTwoName";
			this.teamTwoName.Size = new System.Drawing.Size(170, 38);
			this.teamTwoName.TabIndex = 9;
			this.teamTwoName.Text = "<team two>";
			// 
			// versusLabel
			// 
			this.versusLabel.AutoSize = true;
			this.versusLabel.ForeColor = System.Drawing.Color.Blue;
			this.versusLabel.Location = new System.Drawing.Point(538, 475);
			this.versusLabel.Name = "versusLabel";
			this.versusLabel.Size = new System.Drawing.Size(87, 38);
			this.versusLabel.TabIndex = 12;
			this.versusLabel.Text = "- VS -";
			// 
			// scoreButton
			// 
			this.scoreButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.scoreButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.scoreButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			this.scoreButton.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold);
			this.scoreButton.ForeColor = System.Drawing.Color.Blue;
			this.scoreButton.Location = new System.Drawing.Point(800, 458);
			this.scoreButton.Name = "scoreButton";
			this.scoreButton.Size = new System.Drawing.Size(136, 71);
			this.scoreButton.TabIndex = 13;
			this.scoreButton.Text = "Score";
			this.scoreButton.UseVisualStyleBackColor = true;
			// 
			// TournamentViewerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(994, 695);
			this.Controls.Add(this.scoreButton);
			this.Controls.Add(this.versusLabel);
			this.Controls.Add(this.teamTwoScoreValue);
			this.Controls.Add(this.teamTwoScoreLabel);
			this.Controls.Add(this.teamTwoName);
			this.Controls.Add(this.teamOneScoreValue);
			this.Controls.Add(this.teamOneScoreLabel);
			this.Controls.Add(this.teamOneName);
			this.Controls.Add(this.matchupListbox);
			this.Controls.Add(this.unplayedOnlyCheckbox);
			this.Controls.Add(this.roundDropdown);
			this.Controls.Add(this.RoundLabel);
			this.Controls.Add(this.tournamentName);
			this.Controls.Add(this.headerLabel);
			this.Font = new System.Drawing.Font("Segoe UI", 16.2F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "TournamentViewerForm";
			this.Text = "Tournament Viewer";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label headerLabel;
		private System.Windows.Forms.Label tournamentName;
		private System.Windows.Forms.Label RoundLabel;
		private System.Windows.Forms.ComboBox roundDropdown;
		private System.Windows.Forms.CheckBox unplayedOnlyCheckbox;
		private System.Windows.Forms.ListBox matchupListbox;
		private System.Windows.Forms.Label teamOneName;
		private System.Windows.Forms.Label teamOneScoreLabel;
		private System.Windows.Forms.TextBox teamOneScoreValue;
		private System.Windows.Forms.TextBox teamTwoScoreValue;
		private System.Windows.Forms.Label teamTwoScoreLabel;
		private System.Windows.Forms.Label teamTwoName;
		private System.Windows.Forms.Label versusLabel;
		private System.Windows.Forms.Button scoreButton;
	}
}

