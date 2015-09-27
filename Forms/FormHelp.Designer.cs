namespace WinYourDesktop
{
    partial class FormHelp
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("About");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Run");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Create");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Debug");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Edit");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Home", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Editor");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Debugger");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Settings");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Modes", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("WinYourDesktop", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("About");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Structure");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Desktop files (*.desktop)", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Files", new System.Windows.Forms.TreeNode[] {
            treeNode14});
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Size = new System.Drawing.Size(388, 350);
            this.splitContainer1.SplitterDistance = 129;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Nœud5";
            treeNode1.Text = "About";
            treeNode2.Name = "Nœud8";
            treeNode2.Text = "Run";
            treeNode3.Name = "Nœud9";
            treeNode3.Text = "Create";
            treeNode4.Name = "Nœud10";
            treeNode4.Text = "Debug";
            treeNode5.Name = "Nœud11";
            treeNode5.Text = "Edit";
            treeNode6.Name = "Nœud6";
            treeNode6.Text = "Home";
            treeNode7.Name = "Nœud7";
            treeNode7.Text = "Editor";
            treeNode8.Name = "Nœud12";
            treeNode8.Text = "Debugger";
            treeNode9.Name = "Nœud13";
            treeNode9.Text = "Settings";
            treeNode10.Name = "Nœud14";
            treeNode10.Text = "Modes";
            treeNode11.Name = "Nœud4";
            treeNode11.Text = "WinYourDesktop";
            treeNode12.Name = "Nœud15";
            treeNode12.Text = "About";
            treeNode13.Name = "Nœud16";
            treeNode13.Text = "Structure";
            treeNode14.Name = "Nœud1";
            treeNode14.Text = "Desktop files (*.desktop)";
            treeNode15.Name = "Nœud2";
            treeNode15.Text = "Files";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode15});
            this.treeView1.Size = new System.Drawing.Size(129, 350);
            this.treeView1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(255, 350);
            this.textBox1.TabIndex = 0;
            // 
            // FormHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 350);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormHelp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormHelp";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox1;
    }
}