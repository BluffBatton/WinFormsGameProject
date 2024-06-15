namespace NEW_BALL_GAME2
{
    partial class Window
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Обов'язковий метод для підтримки конструктора.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            scoreLabel = new Label();
            controlsLabel1 = new Label();
            controlsLabel2 = new Label();
            controlsLabel3 = new Label();
            BallTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            scoreLabel.ForeColor = SystemColors.ButtonHighlight;
            scoreLabel.Location = new Point(27, 9);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(63, 14);
            scoreLabel.TabIndex = 0;
            scoreLabel.Text = "Score: 0";
            // 
            // controlsLabel1
            // 
            controlsLabel1.AutoSize = true;
            controlsLabel1.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            controlsLabel1.ForeColor = SystemColors.ButtonHighlight;
            controlsLabel1.Location = new Point(27, 437);
            controlsLabel1.Name = "controlsLabel1";
            controlsLabel1.Size = new Size(210, 14);
            controlsLabel1.TabIndex = 1;
            controlsLabel1.Text = "Press A or D to deploy shield";
            // 
            // controlsLabel2
            // 
            controlsLabel2.AutoSize = true;
            controlsLabel2.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            controlsLabel2.ForeColor = SystemColors.ButtonHighlight;
            controlsLabel2.Location = new Point(332, 437);
            controlsLabel2.Name = "controlsLabel2";
            controlsLabel2.Size = new Size(175, 14);
            controlsLabel2.TabIndex = 2;
            controlsLabel2.Text = "Press S to remove shield";
            // 
            // controlsLabel3
            // 
            controlsLabel3.AutoSize = true;
            controlsLabel3.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            controlsLabel3.ForeColor = SystemColors.ButtonHighlight;
            controlsLabel3.Location = new Point(553, 437);
            controlsLabel3.Name = "controlsLabel3";
            controlsLabel3.Size = new Size(294, 14);
            controlsLabel3.TabIndex = 3;
            controlsLabel3.Text = "Press ESCAPE to immediately end this game";
            // 
            // BallTimer
            // 
            BallTimer.Enabled = true;
            BallTimer.Interval = 200;
            BallTimer.Tick += BallTimer_Tick;
            // 
            // Window
            // 
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(859, 461);
            Controls.Add(controlsLabel3);
            Controls.Add(controlsLabel2);
            Controls.Add(controlsLabel1);
            Controls.Add(scoreLabel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Window";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NEW BALL GAME";
            ResumeLayout(false);
            PerformLayout();
        }

        /// <summary>
        /// Очистка всіх використовуваних ресурсів.
        /// </summary>
        /// <param name="disposing">істинне, якщо керовані ресурси мають бути звільнені; інакше — хибне.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Label scoreLabel;
        private Label controlsLabel1;
        private Label controlsLabel2;
        private Label controlsLabel3;
        private System.Windows.Forms.Timer BallTimer;
    }
}