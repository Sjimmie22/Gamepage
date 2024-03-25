namespace Gamepage_Winforms
{
    partial class Gamepage
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
            this.gameNameLabel = new System.Windows.Forms.Label();
            this.gameListBox = new System.Windows.Forms.ListBox();
            this.gameSubmitButton = new System.Windows.Forms.Button();
            this.nameGameTextBox = new System.Windows.Forms.TextBox();
            this.clipListBox = new System.Windows.Forms.ListBox();
            this.addClipButton = new System.Windows.Forms.Button();
            this.titelClipTextBox = new System.Windows.Forms.TextBox();
            this.clipsGroupBox = new System.Windows.Forms.GroupBox();
            this.commentGroupBox = new System.Windows.Forms.GroupBox();
            this.submitCommentButton = new System.Windows.Forms.Button();
            this.commentListBox = new System.Windows.Forms.ListBox();
            this.commentTextBox = new System.Windows.Forms.TextBox();
            this.editGameButton = new System.Windows.Forms.Button();
            this.deleteGameButton = new System.Windows.Forms.Button();
            this.clipsGroupBox.SuspendLayout();
            this.commentGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameNameLabel
            // 
            this.gameNameLabel.AutoSize = true;
            this.gameNameLabel.Location = new System.Drawing.Point(80, 9);
            this.gameNameLabel.Name = "gameNameLabel";
            this.gameNameLabel.Size = new System.Drawing.Size(52, 20);
            this.gameNameLabel.TabIndex = 0;
            this.gameNameLabel.Text = "Name:";
            // 
            // gameListBox
            // 
            this.gameListBox.FormattingEnabled = true;
            this.gameListBox.ItemHeight = 20;
            this.gameListBox.Location = new System.Drawing.Point(30, 100);
            this.gameListBox.Name = "gameListBox";
            this.gameListBox.Size = new System.Drawing.Size(150, 204);
            this.gameListBox.TabIndex = 1;
            this.gameListBox.SelectedIndexChanged += new System.EventHandler(this.GameListBox_SelectedIndexChanged);
            // 
            // gameSubmitButton
            // 
            this.gameSubmitButton.Location = new System.Drawing.Point(55, 65);
            this.gameSubmitButton.Name = "gameSubmitButton";
            this.gameSubmitButton.Size = new System.Drawing.Size(94, 29);
            this.gameSubmitButton.TabIndex = 2;
            this.gameSubmitButton.Text = "Submit!";
            this.gameSubmitButton.UseVisualStyleBackColor = true;
            this.gameSubmitButton.Click += new System.EventHandler(this.GameSubmitButton_Click);
            // 
            // nameGameTextBox
            // 
            this.nameGameTextBox.Location = new System.Drawing.Point(42, 32);
            this.nameGameTextBox.Name = "nameGameTextBox";
            this.nameGameTextBox.Size = new System.Drawing.Size(125, 27);
            this.nameGameTextBox.TabIndex = 3;
            // 
            // clipListBox
            // 
            this.clipListBox.FormattingEnabled = true;
            this.clipListBox.ItemHeight = 20;
            this.clipListBox.Location = new System.Drawing.Point(71, 94);
            this.clipListBox.Name = "clipListBox";
            this.clipListBox.Size = new System.Drawing.Size(150, 104);
            this.clipListBox.TabIndex = 4;
            this.clipListBox.SelectedIndexChanged += new System.EventHandler(this.clipListBox_SelectedIndexChanged);
            // 
            // addClipButton
            // 
            this.addClipButton.Location = new System.Drawing.Point(101, 26);
            this.addClipButton.Name = "addClipButton";
            this.addClipButton.Size = new System.Drawing.Size(94, 29);
            this.addClipButton.TabIndex = 5;
            this.addClipButton.Text = "Add Clip!";
            this.addClipButton.UseVisualStyleBackColor = true;
            this.addClipButton.Click += new System.EventHandler(this.AddClipButton_Click);
            // 
            // titelClipTextBox
            // 
            this.titelClipTextBox.Location = new System.Drawing.Point(82, 61);
            this.titelClipTextBox.Name = "titelClipTextBox";
            this.titelClipTextBox.Size = new System.Drawing.Size(125, 27);
            this.titelClipTextBox.TabIndex = 6;
            // 
            // clipsGroupBox
            // 
            this.clipsGroupBox.Controls.Add(this.commentGroupBox);
            this.clipsGroupBox.Controls.Add(this.clipListBox);
            this.clipsGroupBox.Controls.Add(this.addClipButton);
            this.clipsGroupBox.Controls.Add(this.titelClipTextBox);
            this.clipsGroupBox.Location = new System.Drawing.Point(344, 12);
            this.clipsGroupBox.Name = "clipsGroupBox";
            this.clipsGroupBox.Size = new System.Drawing.Size(282, 423);
            this.clipsGroupBox.TabIndex = 7;
            this.clipsGroupBox.TabStop = false;
            this.clipsGroupBox.Text = "Clips!";
            this.clipsGroupBox.Visible = false;
            // 
            // commentGroupBox
            // 
            this.commentGroupBox.Controls.Add(this.submitCommentButton);
            this.commentGroupBox.Controls.Add(this.commentListBox);
            this.commentGroupBox.Controls.Add(this.commentTextBox);
            this.commentGroupBox.Location = new System.Drawing.Point(28, 203);
            this.commentGroupBox.Name = "commentGroupBox";
            this.commentGroupBox.Size = new System.Drawing.Size(244, 220);
            this.commentGroupBox.TabIndex = 8;
            this.commentGroupBox.TabStop = false;
            this.commentGroupBox.Text = "Comments!";
            this.commentGroupBox.Visible = false;
            // 
            // submitCommentButton
            // 
            this.submitCommentButton.Location = new System.Drawing.Point(66, 187);
            this.submitCommentButton.Name = "submitCommentButton";
            this.submitCommentButton.Size = new System.Drawing.Size(94, 29);
            this.submitCommentButton.TabIndex = 8;
            this.submitCommentButton.Text = "Submit!";
            this.submitCommentButton.UseVisualStyleBackColor = true;
            this.submitCommentButton.Click += new System.EventHandler(this.submitCommentButton_Click);
            // 
            // commentListBox
            // 
            this.commentListBox.FormattingEnabled = true;
            this.commentListBox.ItemHeight = 20;
            this.commentListBox.Location = new System.Drawing.Point(41, 26);
            this.commentListBox.Name = "commentListBox";
            this.commentListBox.Size = new System.Drawing.Size(150, 104);
            this.commentListBox.TabIndex = 7;
            // 
            // commentTextBox
            // 
            this.commentTextBox.Location = new System.Drawing.Point(44, 136);
            this.commentTextBox.Multiline = true;
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(145, 45);
            this.commentTextBox.TabIndex = 9;
            // 
            // editGameButton
            // 
            this.editGameButton.Location = new System.Drawing.Point(30, 315);
            this.editGameButton.Name = "editGameButton";
            this.editGameButton.Size = new System.Drawing.Size(63, 29);
            this.editGameButton.TabIndex = 8;
            this.editGameButton.Text = "Edit";
            this.editGameButton.UseVisualStyleBackColor = true;
            this.editGameButton.Click += new System.EventHandler(this.editGameButton_Click);
            // 
            // deleteGameButton
            // 
            this.deleteGameButton.Location = new System.Drawing.Point(117, 315);
            this.deleteGameButton.Name = "deleteGameButton";
            this.deleteGameButton.Size = new System.Drawing.Size(63, 29);
            this.deleteGameButton.TabIndex = 9;
            this.deleteGameButton.Text = "Delete";
            this.deleteGameButton.UseVisualStyleBackColor = true;
            this.deleteGameButton.Click += new System.EventHandler(this.deleteGameButton_Click);
            // 
            // Gamepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 450);
            this.Controls.Add(this.deleteGameButton);
            this.Controls.Add(this.editGameButton);
            this.Controls.Add(this.clipsGroupBox);
            this.Controls.Add(this.nameGameTextBox);
            this.Controls.Add(this.gameSubmitButton);
            this.Controls.Add(this.gameListBox);
            this.Controls.Add(this.gameNameLabel);
            this.Name = "Gamepage";
            this.Text = "Gamepage";
            this.clipsGroupBox.ResumeLayout(false);
            this.clipsGroupBox.PerformLayout();
            this.commentGroupBox.ResumeLayout(false);
            this.commentGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label gameNameLabel;
        private ListBox gameListBox;
        private Button gameSubmitButton;
        private TextBox nameGameTextBox;
        private ListBox clipListBox;
        private Button addClipButton;
        private TextBox titelClipTextBox;
        private GroupBox clipsGroupBox;
        private Button submitCommentButton;
        private TextBox commentTextBox;
        private GroupBox commentGroupBox;
        private ListBox commentListBox;
        private Button editGameButton;
        private Button deleteGameButton;
    }
}