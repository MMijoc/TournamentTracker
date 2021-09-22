
namespace TrackerUI
{
	partial class TournamentDashboardForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TournamentDashboardForm));
			this.createPrizeLabel = new System.Windows.Forms.Label();
			this.loadExistingTournamentDropdown = new System.Windows.Forms.ComboBox();
			this.loadExistingTournamentLabel = new System.Windows.Forms.Label();
			this.loadTournamentButton = new System.Windows.Forms.Button();
			this.createTournamentButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// createPrizeLabel
			// 
			this.createPrizeLabel.AutoSize = true;
			this.createPrizeLabel.Font = new System.Drawing.Font("Segoe UI Light", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.createPrizeLabel.ForeColor = System.Drawing.Color.Blue;
			this.createPrizeLabel.Location = new System.Drawing.Point(52, 19);
			this.createPrizeLabel.Name = "createPrizeLabel";
			this.createPrizeLabel.Size = new System.Drawing.Size(488, 62);
			this.createPrizeLabel.TabIndex = 12;
			this.createPrizeLabel.Text = "Tournament Dashboard";
			// 
			// loadExistingTournamentDropdown
			// 
			this.loadExistingTournamentDropdown.ForeColor = System.Drawing.Color.Blue;
			this.loadExistingTournamentDropdown.FormattingEnabled = true;
			this.loadExistingTournamentDropdown.Location = new System.Drawing.Point(76, 159);
			this.loadExistingTournamentDropdown.Name = "loadExistingTournamentDropdown";
			this.loadExistingTournamentDropdown.Size = new System.Drawing.Size(440, 45);
			this.loadExistingTournamentDropdown.TabIndex = 20;
			// 
			// loadExistingTournamentLabel
			// 
			this.loadExistingTournamentLabel.AutoSize = true;
			this.loadExistingTournamentLabel.ForeColor = System.Drawing.Color.Blue;
			this.loadExistingTournamentLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.loadExistingTournamentLabel.Location = new System.Drawing.Point(129, 118);
			this.loadExistingTournamentLabel.Name = "loadExistingTournamentLabel";
			this.loadExistingTournamentLabel.Size = new System.Drawing.Size(334, 38);
			this.loadExistingTournamentLabel.TabIndex = 19;
			this.loadExistingTournamentLabel.Text = "Load Existing Tournament";
			// 
			// loadTournamentButton
			// 
			this.loadTournamentButton.BackColor = System.Drawing.Color.White;
			this.loadTournamentButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.loadTournamentButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.loadTournamentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			this.loadTournamentButton.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.loadTournamentButton.ForeColor = System.Drawing.Color.Blue;
			this.loadTournamentButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.loadTournamentButton.Location = new System.Drawing.Point(158, 210);
			this.loadTournamentButton.Name = "loadTournamentButton";
			this.loadTournamentButton.Size = new System.Drawing.Size(276, 71);
			this.loadTournamentButton.TabIndex = 25;
			this.loadTournamentButton.Text = "Load Tournament";
			this.loadTournamentButton.UseVisualStyleBackColor = false;
			this.loadTournamentButton.Click += new System.EventHandler(this.deleteSelectedTeamMemeberButton_Click);
			// 
			// createTournamentButton
			// 
			this.createTournamentButton.BackColor = System.Drawing.Color.White;
			this.createTournamentButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.createTournamentButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
			this.createTournamentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			this.createTournamentButton.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.createTournamentButton.ForeColor = System.Drawing.Color.Blue;
			this.createTournamentButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.createTournamentButton.Location = new System.Drawing.Point(122, 351);
			this.createTournamentButton.Name = "createTournamentButton";
			this.createTournamentButton.Size = new System.Drawing.Size(348, 92);
			this.createTournamentButton.TabIndex = 26;
			this.createTournamentButton.Text = "Create Tournament";
			this.createTournamentButton.UseVisualStyleBackColor = false;
			this.createTournamentButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// TournamentDashboardForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(592, 503);
			this.Controls.Add(this.createTournamentButton);
			this.Controls.Add(this.loadTournamentButton);
			this.Controls.Add(this.loadExistingTournamentDropdown);
			this.Controls.Add(this.loadExistingTournamentLabel);
			this.Controls.Add(this.createPrizeLabel);
			this.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "TournamentDashboardForm";
			this.Text = "Torunament Dashboard";
			this.Load += new System.EventHandler(this.TorunamentDashboardForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label createPrizeLabel;
		private System.Windows.Forms.ComboBox loadExistingTournamentDropdown;
		private System.Windows.Forms.Label loadExistingTournamentLabel;
		private System.Windows.Forms.Button loadTournamentButton;
		private System.Windows.Forms.Button createTournamentButton;
	}
}