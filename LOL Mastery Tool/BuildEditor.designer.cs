namespace LOL_Mastery_Tool
{
    partial class BuildEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuildEditor));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.edtBuildName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.edtDescription = new System.Windows.Forms.TextBox();
            this.MasteryTree = new System.Windows.Forms.PictureBox();
            this.lblSummonersWrath = new System.Windows.Forms.Label();
            this.lblBruteForce = new System.Windows.Forms.Label();
            this.lblButcher = new System.Windows.Forms.Label();
            this.lblMentalForce = new System.Windows.Forms.Label();
            this.lblToughSkin = new System.Windows.Forms.Label();
            this.lblHardiness = new System.Windows.Forms.Label();
            this.lblResistance = new System.Windows.Forms.Label();
            this.lblSummonersResolve = new System.Windows.Forms.Label();
            this.lblImprovedRecall = new System.Windows.Forms.Label();
            this.lblExpandedMind = new System.Windows.Forms.Label();
            this.lblGoodHands = new System.Windows.Forms.Label();
            this.lblSummonersInsight = new System.Windows.Forms.Label();
            this.lblScout = new System.Windows.Forms.Label();
            this.lblMeditation = new System.Windows.Forms.Label();
            this.lblSwiftness = new System.Windows.Forms.Label();
            this.lblVigor = new System.Windows.Forms.Label();
            this.lblDurability = new System.Windows.Forms.Label();
            this.lblDemolitionist = new System.Windows.Forms.Label();
            this.lblSorcery = new System.Windows.Forms.Label();
            this.lblAlacrity = new System.Windows.Forms.Label();
            this.lblRunicAffinity = new System.Windows.Forms.Label();
            this.lblTransmutation = new System.Windows.Forms.Label();
            this.lblGreed = new System.Windows.Forms.Label();
            this.lblBladedArmor = new System.Windows.Forms.Label();
            this.lblEvasion = new System.Windows.Forms.Label();
            this.lblVetransScars = new System.Windows.Forms.Label();
            this.lblIndomitable = new System.Windows.Forms.Label();
            this.lblHavoc = new System.Windows.Forms.Label();
            this.lblArcaneKnowledge = new System.Windows.Forms.Label();
            this.lblWeaponExpertise = new System.Windows.Forms.Label();
            this.lblDeadlieness = new System.Windows.Forms.Label();
            this.lblSage = new System.Windows.Forms.Label();
            this.lblAwareness = new System.Windows.Forms.Label();
            this.lblWealth = new System.Windows.Forms.Label();
            this.lblEnlightenment = new System.Windows.Forms.Label();
            this.lblInitiator = new System.Windows.Forms.Label();
            this.lblSiegeCommander = new System.Windows.Forms.Label();
            this.lblBlast = new System.Windows.Forms.Label();
            this.lblVampirism = new System.Windows.Forms.Label();
            this.lblLethality = new System.Windows.Forms.Label();
            this.lblIntelligence = new System.Windows.Forms.Label();
            this.lblStrengthOfSpirit = new System.Windows.Forms.Label();
            this.lblMercenary = new System.Windows.Forms.Label();
            this.lblHonorGuard = new System.Windows.Forms.Label();
            this.lblArchmage = new System.Windows.Forms.Label();
            this.lblSunder = new System.Windows.Forms.Label();
            this.lblMastermind = new System.Windows.Forms.Label();
            this.lblJuggernaut = new System.Windows.Forms.Label();
            this.lblExecutioner = new System.Windows.Forms.Label();
            this.lblPointsRemaining = new System.Windows.Forms.Label();
            this.lblOffensePoints = new System.Windows.Forms.Label();
            this.lblDefensePoints = new System.Windows.Forms.Label();
            this.lblUtilityPoints = new System.Windows.Forms.Label();
            this.edtBuildCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.bgwChecker = new System.ComponentModel.BackgroundWorker();
            this.pnlTooltip = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.MasteryTree)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(101, 219);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 37);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Location = new System.Drawing.Point(12, 219);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(81, 37);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "&Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // edtBuildName
            // 
            this.edtBuildName.Location = new System.Drawing.Point(13, 28);
            this.edtBuildName.Name = "edtBuildName";
            this.edtBuildName.Size = new System.Drawing.Size(172, 22);
            this.edtBuildName.TabIndex = 0;
            this.edtBuildName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtBuildName_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Build Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description/Extra Info:";
            // 
            // edtDescription
            // 
            this.edtDescription.Location = new System.Drawing.Point(13, 73);
            this.edtDescription.MaxLength = 2000;
            this.edtDescription.Multiline = true;
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Size = new System.Drawing.Size(172, 139);
            this.edtDescription.TabIndex = 1;
            this.edtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtDescription_KeyDown);
            // 
            // MasteryTree
            // 
            this.MasteryTree.Image = ((System.Drawing.Image)(resources.GetObject("MasteryTree.Image")));
            this.MasteryTree.Location = new System.Drawing.Point(191, 0);
            this.MasteryTree.Name = "MasteryTree";
            this.MasteryTree.Size = new System.Drawing.Size(827, 479);
            this.MasteryTree.TabIndex = 7;
            this.MasteryTree.TabStop = false;
            this.MasteryTree.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MasteryTree_MouseMove);
            this.MasteryTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MasteryTree_MouseUp);
            // 
            // lblSummonersWrath
            // 
            this.lblSummonersWrath.BackColor = System.Drawing.Color.Black;
            this.lblSummonersWrath.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummonersWrath.ForeColor = System.Drawing.Color.Lime;
            this.lblSummonersWrath.Location = new System.Drawing.Point(233, 55);
            this.lblSummonersWrath.Margin = new System.Windows.Forms.Padding(0);
            this.lblSummonersWrath.Name = "lblSummonersWrath";
            this.lblSummonersWrath.Size = new System.Drawing.Size(27, 14);
            this.lblSummonersWrath.TabIndex = 8;
            this.lblSummonersWrath.Tag = "1";
            this.lblSummonersWrath.Text = "0 / 1";
            this.lblSummonersWrath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBruteForce
            // 
            this.lblBruteForce.BackColor = System.Drawing.Color.Black;
            this.lblBruteForce.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBruteForce.ForeColor = System.Drawing.Color.Lime;
            this.lblBruteForce.Location = new System.Drawing.Point(296, 55);
            this.lblBruteForce.Margin = new System.Windows.Forms.Padding(0);
            this.lblBruteForce.Name = "lblBruteForce";
            this.lblBruteForce.Size = new System.Drawing.Size(27, 14);
            this.lblBruteForce.TabIndex = 9;
            this.lblBruteForce.Tag = "3";
            this.lblBruteForce.Text = "0 / 3";
            this.lblBruteForce.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblButcher
            // 
            this.lblButcher.BackColor = System.Drawing.Color.Black;
            this.lblButcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblButcher.ForeColor = System.Drawing.Color.Lime;
            this.lblButcher.Location = new System.Drawing.Point(422, 55);
            this.lblButcher.Margin = new System.Windows.Forms.Padding(0);
            this.lblButcher.Name = "lblButcher";
            this.lblButcher.Size = new System.Drawing.Size(27, 14);
            this.lblButcher.TabIndex = 11;
            this.lblButcher.Tag = "2";
            this.lblButcher.Text = "0 / 2";
            this.lblButcher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMentalForce
            // 
            this.lblMentalForce.BackColor = System.Drawing.Color.Black;
            this.lblMentalForce.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMentalForce.ForeColor = System.Drawing.Color.Lime;
            this.lblMentalForce.Location = new System.Drawing.Point(359, 55);
            this.lblMentalForce.Margin = new System.Windows.Forms.Padding(0);
            this.lblMentalForce.Name = "lblMentalForce";
            this.lblMentalForce.Size = new System.Drawing.Size(27, 14);
            this.lblMentalForce.TabIndex = 10;
            this.lblMentalForce.Tag = "4";
            this.lblMentalForce.Text = "0 / 4";
            this.lblMentalForce.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblToughSkin
            // 
            this.lblToughSkin.BackColor = System.Drawing.Color.Black;
            this.lblToughSkin.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToughSkin.ForeColor = System.Drawing.Color.Lime;
            this.lblToughSkin.Location = new System.Drawing.Point(695, 55);
            this.lblToughSkin.Margin = new System.Windows.Forms.Padding(0);
            this.lblToughSkin.Name = "lblToughSkin";
            this.lblToughSkin.Size = new System.Drawing.Size(27, 14);
            this.lblToughSkin.TabIndex = 15;
            this.lblToughSkin.Tag = "2";
            this.lblToughSkin.Text = "0 / 2";
            this.lblToughSkin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHardiness
            // 
            this.lblHardiness.BackColor = System.Drawing.Color.Black;
            this.lblHardiness.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHardiness.ForeColor = System.Drawing.Color.Lime;
            this.lblHardiness.Location = new System.Drawing.Point(632, 55);
            this.lblHardiness.Margin = new System.Windows.Forms.Padding(0);
            this.lblHardiness.Name = "lblHardiness";
            this.lblHardiness.Size = new System.Drawing.Size(27, 14);
            this.lblHardiness.TabIndex = 14;
            this.lblHardiness.Tag = "3";
            this.lblHardiness.Text = "0 / 3";
            this.lblHardiness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResistance
            // 
            this.lblResistance.BackColor = System.Drawing.Color.Black;
            this.lblResistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResistance.ForeColor = System.Drawing.Color.Lime;
            this.lblResistance.Location = new System.Drawing.Point(569, 55);
            this.lblResistance.Margin = new System.Windows.Forms.Padding(0);
            this.lblResistance.Name = "lblResistance";
            this.lblResistance.Size = new System.Drawing.Size(27, 14);
            this.lblResistance.TabIndex = 13;
            this.lblResistance.Tag = "3";
            this.lblResistance.Text = "0 / 3";
            this.lblResistance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSummonersResolve
            // 
            this.lblSummonersResolve.BackColor = System.Drawing.Color.Black;
            this.lblSummonersResolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummonersResolve.ForeColor = System.Drawing.Color.Lime;
            this.lblSummonersResolve.Location = new System.Drawing.Point(506, 55);
            this.lblSummonersResolve.Margin = new System.Windows.Forms.Padding(0);
            this.lblSummonersResolve.Name = "lblSummonersResolve";
            this.lblSummonersResolve.Size = new System.Drawing.Size(27, 14);
            this.lblSummonersResolve.TabIndex = 12;
            this.lblSummonersResolve.Tag = "1";
            this.lblSummonersResolve.Text = "0 / 1";
            this.lblSummonersResolve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblImprovedRecall
            // 
            this.lblImprovedRecall.BackColor = System.Drawing.Color.Black;
            this.lblImprovedRecall.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImprovedRecall.ForeColor = System.Drawing.Color.Lime;
            this.lblImprovedRecall.Location = new System.Drawing.Point(967, 55);
            this.lblImprovedRecall.Margin = new System.Windows.Forms.Padding(0);
            this.lblImprovedRecall.Name = "lblImprovedRecall";
            this.lblImprovedRecall.Size = new System.Drawing.Size(28, 14);
            this.lblImprovedRecall.TabIndex = 19;
            this.lblImprovedRecall.Tag = "1";
            this.lblImprovedRecall.Text = "0 / 1";
            this.lblImprovedRecall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExpandedMind
            // 
            this.lblExpandedMind.BackColor = System.Drawing.Color.Black;
            this.lblExpandedMind.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpandedMind.ForeColor = System.Drawing.Color.Lime;
            this.lblExpandedMind.Location = new System.Drawing.Point(905, 55);
            this.lblExpandedMind.Margin = new System.Windows.Forms.Padding(0);
            this.lblExpandedMind.Name = "lblExpandedMind";
            this.lblExpandedMind.Size = new System.Drawing.Size(27, 14);
            this.lblExpandedMind.TabIndex = 18;
            this.lblExpandedMind.Tag = "3";
            this.lblExpandedMind.Text = "0 / 3";
            this.lblExpandedMind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGoodHands
            // 
            this.lblGoodHands.BackColor = System.Drawing.Color.Black;
            this.lblGoodHands.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoodHands.ForeColor = System.Drawing.Color.Lime;
            this.lblGoodHands.Location = new System.Drawing.Point(842, 55);
            this.lblGoodHands.Margin = new System.Windows.Forms.Padding(0);
            this.lblGoodHands.Name = "lblGoodHands";
            this.lblGoodHands.Size = new System.Drawing.Size(27, 14);
            this.lblGoodHands.TabIndex = 17;
            this.lblGoodHands.Tag = "3";
            this.lblGoodHands.Text = "0 / 3";
            this.lblGoodHands.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSummonersInsight
            // 
            this.lblSummonersInsight.BackColor = System.Drawing.Color.Black;
            this.lblSummonersInsight.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummonersInsight.ForeColor = System.Drawing.Color.Lime;
            this.lblSummonersInsight.Location = new System.Drawing.Point(779, 55);
            this.lblSummonersInsight.Margin = new System.Windows.Forms.Padding(0);
            this.lblSummonersInsight.Name = "lblSummonersInsight";
            this.lblSummonersInsight.Size = new System.Drawing.Size(27, 14);
            this.lblSummonersInsight.TabIndex = 16;
            this.lblSummonersInsight.Tag = "1";
            this.lblSummonersInsight.Text = "0 / 1";
            this.lblSummonersInsight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScout
            // 
            this.lblScout.BackColor = System.Drawing.Color.Black;
            this.lblScout.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScout.ForeColor = System.Drawing.Color.Lime;
            this.lblScout.Location = new System.Drawing.Point(967, 129);
            this.lblScout.Margin = new System.Windows.Forms.Padding(0);
            this.lblScout.Name = "lblScout";
            this.lblScout.Size = new System.Drawing.Size(28, 14);
            this.lblScout.TabIndex = 27;
            this.lblScout.Tag = "1";
            this.lblScout.Text = "0 / 1";
            this.lblScout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMeditation
            // 
            this.lblMeditation.BackColor = System.Drawing.Color.Black;
            this.lblMeditation.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeditation.ForeColor = System.Drawing.Color.Lime;
            this.lblMeditation.Location = new System.Drawing.Point(905, 129);
            this.lblMeditation.Margin = new System.Windows.Forms.Padding(0);
            this.lblMeditation.Name = "lblMeditation";
            this.lblMeditation.Size = new System.Drawing.Size(27, 14);
            this.lblMeditation.TabIndex = 26;
            this.lblMeditation.Tag = "3";
            this.lblMeditation.Text = "0 / 3";
            this.lblMeditation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSwiftness
            // 
            this.lblSwiftness.BackColor = System.Drawing.Color.Black;
            this.lblSwiftness.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSwiftness.ForeColor = System.Drawing.Color.Lime;
            this.lblSwiftness.Location = new System.Drawing.Point(842, 129);
            this.lblSwiftness.Margin = new System.Windows.Forms.Padding(0);
            this.lblSwiftness.Name = "lblSwiftness";
            this.lblSwiftness.Size = new System.Drawing.Size(27, 14);
            this.lblSwiftness.TabIndex = 25;
            this.lblSwiftness.Tag = "4";
            this.lblSwiftness.Text = "0 / 4";
            this.lblSwiftness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVigor
            // 
            this.lblVigor.BackColor = System.Drawing.Color.Black;
            this.lblVigor.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVigor.ForeColor = System.Drawing.Color.Lime;
            this.lblVigor.Location = new System.Drawing.Point(632, 129);
            this.lblVigor.Margin = new System.Windows.Forms.Padding(0);
            this.lblVigor.Name = "lblVigor";
            this.lblVigor.Size = new System.Drawing.Size(27, 14);
            this.lblVigor.TabIndex = 24;
            this.lblVigor.Tag = "3";
            this.lblVigor.Text = "0 / 3";
            this.lblVigor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDurability
            // 
            this.lblDurability.BackColor = System.Drawing.Color.Black;
            this.lblDurability.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurability.ForeColor = System.Drawing.Color.Lime;
            this.lblDurability.Location = new System.Drawing.Point(569, 129);
            this.lblDurability.Margin = new System.Windows.Forms.Padding(0);
            this.lblDurability.Name = "lblDurability";
            this.lblDurability.Size = new System.Drawing.Size(27, 14);
            this.lblDurability.TabIndex = 23;
            this.lblDurability.Tag = "4";
            this.lblDurability.Text = "0 / 4";
            this.lblDurability.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDemolitionist
            // 
            this.lblDemolitionist.BackColor = System.Drawing.Color.Black;
            this.lblDemolitionist.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDemolitionist.ForeColor = System.Drawing.Color.Lime;
            this.lblDemolitionist.Location = new System.Drawing.Point(422, 129);
            this.lblDemolitionist.Margin = new System.Windows.Forms.Padding(0);
            this.lblDemolitionist.Name = "lblDemolitionist";
            this.lblDemolitionist.Size = new System.Drawing.Size(27, 14);
            this.lblDemolitionist.TabIndex = 22;
            this.lblDemolitionist.Tag = "1";
            this.lblDemolitionist.Text = "0 / 1";
            this.lblDemolitionist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSorcery
            // 
            this.lblSorcery.BackColor = System.Drawing.Color.Black;
            this.lblSorcery.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSorcery.ForeColor = System.Drawing.Color.Lime;
            this.lblSorcery.Location = new System.Drawing.Point(359, 129);
            this.lblSorcery.Margin = new System.Windows.Forms.Padding(0);
            this.lblSorcery.Name = "lblSorcery";
            this.lblSorcery.Size = new System.Drawing.Size(27, 14);
            this.lblSorcery.TabIndex = 21;
            this.lblSorcery.Tag = "4";
            this.lblSorcery.Text = "0 / 4";
            this.lblSorcery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAlacrity
            // 
            this.lblAlacrity.BackColor = System.Drawing.Color.Black;
            this.lblAlacrity.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlacrity.ForeColor = System.Drawing.Color.Lime;
            this.lblAlacrity.Location = new System.Drawing.Point(296, 129);
            this.lblAlacrity.Margin = new System.Windows.Forms.Padding(0);
            this.lblAlacrity.Name = "lblAlacrity";
            this.lblAlacrity.Size = new System.Drawing.Size(27, 14);
            this.lblAlacrity.TabIndex = 20;
            this.lblAlacrity.Tag = "4";
            this.lblAlacrity.Text = "0 / 4";
            this.lblAlacrity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRunicAffinity
            // 
            this.lblRunicAffinity.BackColor = System.Drawing.Color.Black;
            this.lblRunicAffinity.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRunicAffinity.ForeColor = System.Drawing.Color.Lime;
            this.lblRunicAffinity.Location = new System.Drawing.Point(967, 203);
            this.lblRunicAffinity.Margin = new System.Windows.Forms.Padding(0);
            this.lblRunicAffinity.Name = "lblRunicAffinity";
            this.lblRunicAffinity.Size = new System.Drawing.Size(28, 14);
            this.lblRunicAffinity.TabIndex = 38;
            this.lblRunicAffinity.Tag = "1";
            this.lblRunicAffinity.Text = "0 / 1";
            this.lblRunicAffinity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTransmutation
            // 
            this.lblTransmutation.BackColor = System.Drawing.Color.Black;
            this.lblTransmutation.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransmutation.ForeColor = System.Drawing.Color.Lime;
            this.lblTransmutation.Location = new System.Drawing.Point(905, 203);
            this.lblTransmutation.Margin = new System.Windows.Forms.Padding(0);
            this.lblTransmutation.Name = "lblTransmutation";
            this.lblTransmutation.Size = new System.Drawing.Size(27, 14);
            this.lblTransmutation.TabIndex = 37;
            this.lblTransmutation.Tag = "3";
            this.lblTransmutation.Text = "0 / 3";
            this.lblTransmutation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGreed
            // 
            this.lblGreed.BackColor = System.Drawing.Color.Black;
            this.lblGreed.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreed.ForeColor = System.Drawing.Color.Lime;
            this.lblGreed.Location = new System.Drawing.Point(842, 203);
            this.lblGreed.Margin = new System.Windows.Forms.Padding(0);
            this.lblGreed.Name = "lblGreed";
            this.lblGreed.Size = new System.Drawing.Size(27, 14);
            this.lblGreed.TabIndex = 36;
            this.lblGreed.Tag = "4";
            this.lblGreed.Text = "0 / 4";
            this.lblGreed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBladedArmor
            // 
            this.lblBladedArmor.BackColor = System.Drawing.Color.Black;
            this.lblBladedArmor.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBladedArmor.ForeColor = System.Drawing.Color.Lime;
            this.lblBladedArmor.Location = new System.Drawing.Point(695, 203);
            this.lblBladedArmor.Margin = new System.Windows.Forms.Padding(0);
            this.lblBladedArmor.Name = "lblBladedArmor";
            this.lblBladedArmor.Size = new System.Drawing.Size(27, 14);
            this.lblBladedArmor.TabIndex = 35;
            this.lblBladedArmor.Tag = "1";
            this.lblBladedArmor.Text = "0 / 1";
            this.lblBladedArmor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEvasion
            // 
            this.lblEvasion.BackColor = System.Drawing.Color.Black;
            this.lblEvasion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvasion.ForeColor = System.Drawing.Color.Lime;
            this.lblEvasion.Location = new System.Drawing.Point(632, 203);
            this.lblEvasion.Margin = new System.Windows.Forms.Padding(0);
            this.lblEvasion.Name = "lblEvasion";
            this.lblEvasion.Size = new System.Drawing.Size(27, 14);
            this.lblEvasion.TabIndex = 34;
            this.lblEvasion.Tag = "3";
            this.lblEvasion.Text = "0 / 3";
            this.lblEvasion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVetransScars
            // 
            this.lblVetransScars.BackColor = System.Drawing.Color.Black;
            this.lblVetransScars.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVetransScars.ForeColor = System.Drawing.Color.Lime;
            this.lblVetransScars.Location = new System.Drawing.Point(569, 203);
            this.lblVetransScars.Margin = new System.Windows.Forms.Padding(0);
            this.lblVetransScars.Name = "lblVetransScars";
            this.lblVetransScars.Size = new System.Drawing.Size(27, 14);
            this.lblVetransScars.TabIndex = 33;
            this.lblVetransScars.Tag = "1";
            this.lblVetransScars.Text = "0 / 1";
            this.lblVetransScars.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIndomitable
            // 
            this.lblIndomitable.BackColor = System.Drawing.Color.Black;
            this.lblIndomitable.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndomitable.ForeColor = System.Drawing.Color.Lime;
            this.lblIndomitable.Location = new System.Drawing.Point(506, 203);
            this.lblIndomitable.Margin = new System.Windows.Forms.Padding(0);
            this.lblIndomitable.Name = "lblIndomitable";
            this.lblIndomitable.Size = new System.Drawing.Size(27, 14);
            this.lblIndomitable.TabIndex = 32;
            this.lblIndomitable.Tag = "2";
            this.lblIndomitable.Text = "0 / 2";
            this.lblIndomitable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHavoc
            // 
            this.lblHavoc.BackColor = System.Drawing.Color.Black;
            this.lblHavoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHavoc.ForeColor = System.Drawing.Color.Lime;
            this.lblHavoc.Location = new System.Drawing.Point(422, 203);
            this.lblHavoc.Margin = new System.Windows.Forms.Padding(0);
            this.lblHavoc.Name = "lblHavoc";
            this.lblHavoc.Size = new System.Drawing.Size(27, 14);
            this.lblHavoc.TabIndex = 31;
            this.lblHavoc.Tag = "3";
            this.lblHavoc.Text = "0 / 3";
            this.lblHavoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblArcaneKnowledge
            // 
            this.lblArcaneKnowledge.BackColor = System.Drawing.Color.Black;
            this.lblArcaneKnowledge.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArcaneKnowledge.ForeColor = System.Drawing.Color.Lime;
            this.lblArcaneKnowledge.Location = new System.Drawing.Point(359, 203);
            this.lblArcaneKnowledge.Margin = new System.Windows.Forms.Padding(0);
            this.lblArcaneKnowledge.Name = "lblArcaneKnowledge";
            this.lblArcaneKnowledge.Size = new System.Drawing.Size(27, 14);
            this.lblArcaneKnowledge.TabIndex = 30;
            this.lblArcaneKnowledge.Tag = "1";
            this.lblArcaneKnowledge.Text = "0 / 1";
            this.lblArcaneKnowledge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWeaponExpertise
            // 
            this.lblWeaponExpertise.BackColor = System.Drawing.Color.Black;
            this.lblWeaponExpertise.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeaponExpertise.ForeColor = System.Drawing.Color.Lime;
            this.lblWeaponExpertise.Location = new System.Drawing.Point(296, 203);
            this.lblWeaponExpertise.Margin = new System.Windows.Forms.Padding(0);
            this.lblWeaponExpertise.Name = "lblWeaponExpertise";
            this.lblWeaponExpertise.Size = new System.Drawing.Size(27, 14);
            this.lblWeaponExpertise.TabIndex = 29;
            this.lblWeaponExpertise.Tag = "1";
            this.lblWeaponExpertise.Text = "0 / 1";
            this.lblWeaponExpertise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDeadlieness
            // 
            this.lblDeadlieness.BackColor = System.Drawing.Color.Black;
            this.lblDeadlieness.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeadlieness.ForeColor = System.Drawing.Color.Lime;
            this.lblDeadlieness.Location = new System.Drawing.Point(233, 203);
            this.lblDeadlieness.Margin = new System.Windows.Forms.Padding(0);
            this.lblDeadlieness.Name = "lblDeadlieness";
            this.lblDeadlieness.Size = new System.Drawing.Size(27, 14);
            this.lblDeadlieness.TabIndex = 28;
            this.lblDeadlieness.Tag = "4";
            this.lblDeadlieness.Text = "0 / 4";
            this.lblDeadlieness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSage
            // 
            this.lblSage.BackColor = System.Drawing.Color.Black;
            this.lblSage.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSage.ForeColor = System.Drawing.Color.Lime;
            this.lblSage.Location = new System.Drawing.Point(967, 277);
            this.lblSage.Margin = new System.Windows.Forms.Padding(0);
            this.lblSage.Name = "lblSage";
            this.lblSage.Size = new System.Drawing.Size(28, 14);
            this.lblSage.TabIndex = 47;
            this.lblSage.Tag = "1";
            this.lblSage.Text = "0 / 1";
            this.lblSage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAwareness
            // 
            this.lblAwareness.BackColor = System.Drawing.Color.Black;
            this.lblAwareness.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAwareness.ForeColor = System.Drawing.Color.Lime;
            this.lblAwareness.Location = new System.Drawing.Point(905, 277);
            this.lblAwareness.Margin = new System.Windows.Forms.Padding(0);
            this.lblAwareness.Name = "lblAwareness";
            this.lblAwareness.Size = new System.Drawing.Size(27, 14);
            this.lblAwareness.TabIndex = 46;
            this.lblAwareness.Tag = "4";
            this.lblAwareness.Text = "0 / 4";
            this.lblAwareness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWealth
            // 
            this.lblWealth.BackColor = System.Drawing.Color.Black;
            this.lblWealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWealth.ForeColor = System.Drawing.Color.Lime;
            this.lblWealth.Location = new System.Drawing.Point(842, 277);
            this.lblWealth.Margin = new System.Windows.Forms.Padding(0);
            this.lblWealth.Name = "lblWealth";
            this.lblWealth.Size = new System.Drawing.Size(27, 14);
            this.lblWealth.TabIndex = 45;
            this.lblWealth.Tag = "2";
            this.lblWealth.Text = "0 / 2";
            this.lblWealth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEnlightenment
            // 
            this.lblEnlightenment.BackColor = System.Drawing.Color.Black;
            this.lblEnlightenment.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnlightenment.ForeColor = System.Drawing.Color.Lime;
            this.lblEnlightenment.Location = new System.Drawing.Point(632, 277);
            this.lblEnlightenment.Margin = new System.Windows.Forms.Padding(0);
            this.lblEnlightenment.Name = "lblEnlightenment";
            this.lblEnlightenment.Size = new System.Drawing.Size(27, 14);
            this.lblEnlightenment.TabIndex = 44;
            this.lblEnlightenment.Tag = "3";
            this.lblEnlightenment.Text = "0 / 3";
            this.lblEnlightenment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInitiator
            // 
            this.lblInitiator.BackColor = System.Drawing.Color.Black;
            this.lblInitiator.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitiator.ForeColor = System.Drawing.Color.Lime;
            this.lblInitiator.Location = new System.Drawing.Point(569, 277);
            this.lblInitiator.Margin = new System.Windows.Forms.Padding(0);
            this.lblInitiator.Name = "lblInitiator";
            this.lblInitiator.Size = new System.Drawing.Size(27, 14);
            this.lblInitiator.TabIndex = 43;
            this.lblInitiator.Tag = "3";
            this.lblInitiator.Text = "0 / 3";
            this.lblInitiator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSiegeCommander
            // 
            this.lblSiegeCommander.BackColor = System.Drawing.Color.Black;
            this.lblSiegeCommander.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSiegeCommander.ForeColor = System.Drawing.Color.Lime;
            this.lblSiegeCommander.Location = new System.Drawing.Point(506, 277);
            this.lblSiegeCommander.Margin = new System.Windows.Forms.Padding(0);
            this.lblSiegeCommander.Name = "lblSiegeCommander";
            this.lblSiegeCommander.Size = new System.Drawing.Size(27, 14);
            this.lblSiegeCommander.TabIndex = 42;
            this.lblSiegeCommander.Tag = "1";
            this.lblSiegeCommander.Text = "0 / 1";
            this.lblSiegeCommander.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBlast
            // 
            this.lblBlast.BackColor = System.Drawing.Color.Black;
            this.lblBlast.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlast.ForeColor = System.Drawing.Color.Lime;
            this.lblBlast.Location = new System.Drawing.Point(359, 277);
            this.lblBlast.Margin = new System.Windows.Forms.Padding(0);
            this.lblBlast.Name = "lblBlast";
            this.lblBlast.Size = new System.Drawing.Size(27, 14);
            this.lblBlast.TabIndex = 41;
            this.lblBlast.Tag = "4";
            this.lblBlast.Text = "0 / 4";
            this.lblBlast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVampirism
            // 
            this.lblVampirism.BackColor = System.Drawing.Color.Black;
            this.lblVampirism.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVampirism.ForeColor = System.Drawing.Color.Lime;
            this.lblVampirism.Location = new System.Drawing.Point(296, 277);
            this.lblVampirism.Margin = new System.Windows.Forms.Padding(0);
            this.lblVampirism.Name = "lblVampirism";
            this.lblVampirism.Size = new System.Drawing.Size(27, 14);
            this.lblVampirism.TabIndex = 40;
            this.lblVampirism.Tag = "3";
            this.lblVampirism.Text = "0 / 3";
            this.lblVampirism.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLethality
            // 
            this.lblLethality.BackColor = System.Drawing.Color.Black;
            this.lblLethality.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLethality.ForeColor = System.Drawing.Color.Lime;
            this.lblLethality.Location = new System.Drawing.Point(233, 277);
            this.lblLethality.Margin = new System.Windows.Forms.Padding(0);
            this.lblLethality.Name = "lblLethality";
            this.lblLethality.Size = new System.Drawing.Size(27, 14);
            this.lblLethality.TabIndex = 39;
            this.lblLethality.Tag = "1";
            this.lblLethality.Text = "0 / 1";
            this.lblLethality.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIntelligence
            // 
            this.lblIntelligence.BackColor = System.Drawing.Color.Black;
            this.lblIntelligence.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntelligence.ForeColor = System.Drawing.Color.Lime;
            this.lblIntelligence.Location = new System.Drawing.Point(905, 351);
            this.lblIntelligence.Margin = new System.Windows.Forms.Padding(0);
            this.lblIntelligence.Name = "lblIntelligence";
            this.lblIntelligence.Size = new System.Drawing.Size(27, 14);
            this.lblIntelligence.TabIndex = 53;
            this.lblIntelligence.Tag = "3";
            this.lblIntelligence.Text = "0 / 3";
            this.lblIntelligence.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStrengthOfSpirit
            // 
            this.lblStrengthOfSpirit.BackColor = System.Drawing.Color.Black;
            this.lblStrengthOfSpirit.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStrengthOfSpirit.ForeColor = System.Drawing.Color.Lime;
            this.lblStrengthOfSpirit.Location = new System.Drawing.Point(842, 351);
            this.lblStrengthOfSpirit.Margin = new System.Windows.Forms.Padding(0);
            this.lblStrengthOfSpirit.Name = "lblStrengthOfSpirit";
            this.lblStrengthOfSpirit.Size = new System.Drawing.Size(27, 14);
            this.lblStrengthOfSpirit.TabIndex = 52;
            this.lblStrengthOfSpirit.Tag = "3";
            this.lblStrengthOfSpirit.Text = "0 / 3";
            this.lblStrengthOfSpirit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMercenary
            // 
            this.lblMercenary.BackColor = System.Drawing.Color.Black;
            this.lblMercenary.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMercenary.ForeColor = System.Drawing.Color.Lime;
            this.lblMercenary.Location = new System.Drawing.Point(632, 351);
            this.lblMercenary.Margin = new System.Windows.Forms.Padding(0);
            this.lblMercenary.Name = "lblMercenary";
            this.lblMercenary.Size = new System.Drawing.Size(27, 14);
            this.lblMercenary.TabIndex = 51;
            this.lblMercenary.Tag = "3";
            this.lblMercenary.Text = "0 / 3";
            this.lblMercenary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHonorGuard
            // 
            this.lblHonorGuard.BackColor = System.Drawing.Color.Black;
            this.lblHonorGuard.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHonorGuard.ForeColor = System.Drawing.Color.Lime;
            this.lblHonorGuard.Location = new System.Drawing.Point(569, 351);
            this.lblHonorGuard.Margin = new System.Windows.Forms.Padding(0);
            this.lblHonorGuard.Name = "lblHonorGuard";
            this.lblHonorGuard.Size = new System.Drawing.Size(27, 14);
            this.lblHonorGuard.TabIndex = 50;
            this.lblHonorGuard.Tag = "3";
            this.lblHonorGuard.Text = "0 / 3";
            this.lblHonorGuard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblArchmage
            // 
            this.lblArchmage.BackColor = System.Drawing.Color.Black;
            this.lblArchmage.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArchmage.ForeColor = System.Drawing.Color.Lime;
            this.lblArchmage.Location = new System.Drawing.Point(359, 351);
            this.lblArchmage.Margin = new System.Windows.Forms.Padding(0);
            this.lblArchmage.Name = "lblArchmage";
            this.lblArchmage.Size = new System.Drawing.Size(27, 14);
            this.lblArchmage.TabIndex = 49;
            this.lblArchmage.Tag = "4";
            this.lblArchmage.Text = "0 / 4";
            this.lblArchmage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSunder
            // 
            this.lblSunder.BackColor = System.Drawing.Color.Black;
            this.lblSunder.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSunder.ForeColor = System.Drawing.Color.Lime;
            this.lblSunder.Location = new System.Drawing.Point(296, 351);
            this.lblSunder.Margin = new System.Windows.Forms.Padding(0);
            this.lblSunder.Name = "lblSunder";
            this.lblSunder.Size = new System.Drawing.Size(27, 14);
            this.lblSunder.TabIndex = 48;
            this.lblSunder.Tag = "3";
            this.lblSunder.Text = "0 / 3";
            this.lblSunder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMastermind
            // 
            this.lblMastermind.BackColor = System.Drawing.Color.Black;
            this.lblMastermind.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMastermind.ForeColor = System.Drawing.Color.Lime;
            this.lblMastermind.Location = new System.Drawing.Point(905, 425);
            this.lblMastermind.Margin = new System.Windows.Forms.Padding(0);
            this.lblMastermind.Name = "lblMastermind";
            this.lblMastermind.Size = new System.Drawing.Size(27, 14);
            this.lblMastermind.TabIndex = 56;
            this.lblMastermind.Tag = "1";
            this.lblMastermind.Text = "0 / 1";
            this.lblMastermind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJuggernaut
            // 
            this.lblJuggernaut.BackColor = System.Drawing.Color.Black;
            this.lblJuggernaut.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJuggernaut.ForeColor = System.Drawing.Color.Lime;
            this.lblJuggernaut.Location = new System.Drawing.Point(569, 425);
            this.lblJuggernaut.Margin = new System.Windows.Forms.Padding(0);
            this.lblJuggernaut.Name = "lblJuggernaut";
            this.lblJuggernaut.Size = new System.Drawing.Size(27, 14);
            this.lblJuggernaut.TabIndex = 55;
            this.lblJuggernaut.Tag = "1";
            this.lblJuggernaut.Text = "0 / 1";
            this.lblJuggernaut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExecutioner
            // 
            this.lblExecutioner.BackColor = System.Drawing.Color.Black;
            this.lblExecutioner.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExecutioner.ForeColor = System.Drawing.Color.Lime;
            this.lblExecutioner.Location = new System.Drawing.Point(296, 425);
            this.lblExecutioner.Margin = new System.Windows.Forms.Padding(0);
            this.lblExecutioner.Name = "lblExecutioner";
            this.lblExecutioner.Size = new System.Drawing.Size(27, 14);
            this.lblExecutioner.TabIndex = 54;
            this.lblExecutioner.Tag = "1";
            this.lblExecutioner.Text = "0 / 1";
            this.lblExecutioner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPointsRemaining
            // 
            this.lblPointsRemaining.AutoSize = true;
            this.lblPointsRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsRemaining.Location = new System.Drawing.Point(12, 305);
            this.lblPointsRemaining.Name = "lblPointsRemaining";
            this.lblPointsRemaining.Size = new System.Drawing.Size(159, 20);
            this.lblPointsRemaining.TabIndex = 57;
            this.lblPointsRemaining.Tag = "Points Remaining: ";
            this.lblPointsRemaining.Text = "Points Remaining: 30";
            // 
            // lblOffensePoints
            // 
            this.lblOffensePoints.AutoSize = true;
            this.lblOffensePoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOffensePoints.Location = new System.Drawing.Point(12, 325);
            this.lblOffensePoints.Name = "lblOffensePoints";
            this.lblOffensePoints.Size = new System.Drawing.Size(83, 20);
            this.lblOffensePoints.TabIndex = 58;
            this.lblOffensePoints.Tag = "Offense: ";
            this.lblOffensePoints.Text = "Offense: 0";
            // 
            // lblDefensePoints
            // 
            this.lblDefensePoints.AutoSize = true;
            this.lblDefensePoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefensePoints.Location = new System.Drawing.Point(12, 345);
            this.lblDefensePoints.Name = "lblDefensePoints";
            this.lblDefensePoints.Size = new System.Drawing.Size(87, 20);
            this.lblDefensePoints.TabIndex = 59;
            this.lblDefensePoints.Tag = "Defense: ";
            this.lblDefensePoints.Text = "Defense: 0";
            // 
            // lblUtilityPoints
            // 
            this.lblUtilityPoints.AutoSize = true;
            this.lblUtilityPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUtilityPoints.Location = new System.Drawing.Point(12, 365);
            this.lblUtilityPoints.Name = "lblUtilityPoints";
            this.lblUtilityPoints.Size = new System.Drawing.Size(64, 20);
            this.lblUtilityPoints.TabIndex = 60;
            this.lblUtilityPoints.Tag = "Utility: ";
            this.lblUtilityPoints.Text = "Utility: 0";
            // 
            // edtBuildCode
            // 
            this.edtBuildCode.Enabled = false;
            this.edtBuildCode.Location = new System.Drawing.Point(16, 411);
            this.edtBuildCode.Multiline = true;
            this.edtBuildCode.Name = "edtBuildCode";
            this.edtBuildCode.Size = new System.Drawing.Size(169, 56);
            this.edtBuildCode.TabIndex = 61;
            this.edtBuildCode.Text = "00000000000000000\r\n0000000000000000\r\n0000000000000000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 385);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 20);
            this.label7.TabIndex = 62;
            this.label7.Text = "Build Code:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(16, 264);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 37);
            this.button1.TabIndex = 63;
            this.button1.Text = "&Reset Build";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bgwChecker
            // 
            this.bgwChecker.WorkerReportsProgress = true;
            this.bgwChecker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwChecker_DoWork);
            // 
            // pnlTooltip
            // 
            this.pnlTooltip.Location = new System.Drawing.Point(424, 351);
            this.pnlTooltip.Name = "pnlTooltip";
            this.pnlTooltip.Size = new System.Drawing.Size(200, 100);
            this.pnlTooltip.TabIndex = 64;
            this.pnlTooltip.Visible = false;
            this.pnlTooltip.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTooltip_Paint);
            this.pnlTooltip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTooltip_MouseMove);
            // 
            // BuildEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 479);
            this.Controls.Add(this.pnlTooltip);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.edtBuildCode);
            this.Controls.Add(this.lblUtilityPoints);
            this.Controls.Add(this.lblDefensePoints);
            this.Controls.Add(this.lblOffensePoints);
            this.Controls.Add(this.lblPointsRemaining);
            this.Controls.Add(this.lblMastermind);
            this.Controls.Add(this.lblJuggernaut);
            this.Controls.Add(this.lblExecutioner);
            this.Controls.Add(this.lblIntelligence);
            this.Controls.Add(this.lblStrengthOfSpirit);
            this.Controls.Add(this.lblMercenary);
            this.Controls.Add(this.lblHonorGuard);
            this.Controls.Add(this.lblArchmage);
            this.Controls.Add(this.lblSunder);
            this.Controls.Add(this.lblSage);
            this.Controls.Add(this.lblAwareness);
            this.Controls.Add(this.lblWealth);
            this.Controls.Add(this.lblEnlightenment);
            this.Controls.Add(this.lblInitiator);
            this.Controls.Add(this.lblSiegeCommander);
            this.Controls.Add(this.lblBlast);
            this.Controls.Add(this.lblVampirism);
            this.Controls.Add(this.lblLethality);
            this.Controls.Add(this.lblRunicAffinity);
            this.Controls.Add(this.lblTransmutation);
            this.Controls.Add(this.lblGreed);
            this.Controls.Add(this.lblBladedArmor);
            this.Controls.Add(this.lblEvasion);
            this.Controls.Add(this.lblVetransScars);
            this.Controls.Add(this.lblIndomitable);
            this.Controls.Add(this.lblHavoc);
            this.Controls.Add(this.lblArcaneKnowledge);
            this.Controls.Add(this.lblWeaponExpertise);
            this.Controls.Add(this.lblDeadlieness);
            this.Controls.Add(this.lblScout);
            this.Controls.Add(this.lblMeditation);
            this.Controls.Add(this.lblSwiftness);
            this.Controls.Add(this.lblVigor);
            this.Controls.Add(this.lblDurability);
            this.Controls.Add(this.lblDemolitionist);
            this.Controls.Add(this.lblSorcery);
            this.Controls.Add(this.lblAlacrity);
            this.Controls.Add(this.lblImprovedRecall);
            this.Controls.Add(this.lblExpandedMind);
            this.Controls.Add(this.lblGoodHands);
            this.Controls.Add(this.lblSummonersInsight);
            this.Controls.Add(this.lblToughSkin);
            this.Controls.Add(this.lblHardiness);
            this.Controls.Add(this.lblResistance);
            this.Controls.Add(this.lblSummonersResolve);
            this.Controls.Add(this.lblButcher);
            this.Controls.Add(this.lblMentalForce);
            this.Controls.Add(this.lblBruteForce);
            this.Controls.Add(this.lblSummonersWrath);
            this.Controls.Add(this.MasteryTree);
            this.Controls.Add(this.edtDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtBuildName);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuildEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Build";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BuildEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.MasteryTree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TextBox edtBuildName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edtDescription;
        private System.Windows.Forms.PictureBox MasteryTree;
        private System.Windows.Forms.Label lblSummonersWrath;
        private System.Windows.Forms.Label lblBruteForce;
        private System.Windows.Forms.Label lblButcher;
        private System.Windows.Forms.Label lblMentalForce;
        private System.Windows.Forms.Label lblToughSkin;
        private System.Windows.Forms.Label lblHardiness;
        private System.Windows.Forms.Label lblResistance;
        private System.Windows.Forms.Label lblSummonersResolve;
        private System.Windows.Forms.Label lblImprovedRecall;
        private System.Windows.Forms.Label lblExpandedMind;
        private System.Windows.Forms.Label lblGoodHands;
        private System.Windows.Forms.Label lblSummonersInsight;
        private System.Windows.Forms.Label lblScout;
        private System.Windows.Forms.Label lblMeditation;
        private System.Windows.Forms.Label lblSwiftness;
        private System.Windows.Forms.Label lblVigor;
        private System.Windows.Forms.Label lblDurability;
        private System.Windows.Forms.Label lblDemolitionist;
        private System.Windows.Forms.Label lblSorcery;
        private System.Windows.Forms.Label lblAlacrity;
        private System.Windows.Forms.Label lblRunicAffinity;
        private System.Windows.Forms.Label lblTransmutation;
        private System.Windows.Forms.Label lblGreed;
        private System.Windows.Forms.Label lblBladedArmor;
        private System.Windows.Forms.Label lblEvasion;
        private System.Windows.Forms.Label lblVetransScars;
        private System.Windows.Forms.Label lblIndomitable;
        private System.Windows.Forms.Label lblHavoc;
        private System.Windows.Forms.Label lblArcaneKnowledge;
        private System.Windows.Forms.Label lblWeaponExpertise;
        private System.Windows.Forms.Label lblDeadlieness;
        private System.Windows.Forms.Label lblSage;
        private System.Windows.Forms.Label lblAwareness;
        private System.Windows.Forms.Label lblWealth;
        private System.Windows.Forms.Label lblEnlightenment;
        private System.Windows.Forms.Label lblInitiator;
        private System.Windows.Forms.Label lblSiegeCommander;
        private System.Windows.Forms.Label lblBlast;
        private System.Windows.Forms.Label lblVampirism;
        private System.Windows.Forms.Label lblLethality;
        private System.Windows.Forms.Label lblIntelligence;
        private System.Windows.Forms.Label lblStrengthOfSpirit;
        private System.Windows.Forms.Label lblMercenary;
        private System.Windows.Forms.Label lblHonorGuard;
        private System.Windows.Forms.Label lblArchmage;
        private System.Windows.Forms.Label lblSunder;
        private System.Windows.Forms.Label lblMastermind;
        private System.Windows.Forms.Label lblJuggernaut;
        private System.Windows.Forms.Label lblExecutioner;
        private System.Windows.Forms.Label lblPointsRemaining;
        private System.Windows.Forms.Label lblOffensePoints;
        private System.Windows.Forms.Label lblDefensePoints;
        private System.Windows.Forms.Label lblUtilityPoints;
        private System.Windows.Forms.TextBox edtBuildCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker bgwChecker;
        private System.Windows.Forms.Panel pnlTooltip;
    }
}