namespace XenAdmin.Wizards.RollingUpgradeWizard
{
    partial class RollingUpgradeWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RollingUpgradeWizard));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWizard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XSHelpButton)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxWizard
            // 
            resources.ApplyResources(this.pictureBoxWizard, "pictureBoxWizard");
            this.pictureBoxWizard.Image = global::XenAdmin.Properties.Resources._000_UpgradePool_h32bit_32;
            // 
            // XSHelpButton
            // 
            resources.ApplyResources(this.XSHelpButton, "XSHelpButton");
            // 
            // RollingUpgradeWizard
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "RollingUpgradeWizard";
            this.MaximizeBox = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWizard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XSHelpButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

    }
}