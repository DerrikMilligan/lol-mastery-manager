using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Timers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows;

using System.Runtime.InteropServices;

namespace LOL_Mastery_Tool
{
    public partial class BuildEditor : Form
    {
        static BuildEditor Editor;

        #region Setup Mastery Variables
        private static List<List<Mastery>> Masteries;
        private static List<List<Label>>   Labels;
        private static List<Mastery> offenseMasteries;
        private static List<Label>   offenseLabels;
        private static List<Mastery> defenseMasteries;
        private static List<Label>   defenseLabels;
        private static List<Mastery> utilityMasteries;
        private static List<Label>   utilityLabels;
        private static Point spacer;
        private static Point offense;
        private static Point defense;
        private static Point utility;
        private static List<Mastery> TreeMasteries;
        private static Mastery mOffense;
        private static Mastery mDefense;
        private static Mastery mUtility;
        private static List<Label> PointLabels;
        private static int PointsRemaining = 30;
        #region Offense Vars
        private static Mastery mSummonersWrath;
        private static Mastery mBruteForce;
        private static Mastery mMentalForce;
        private static Mastery mButcher;
        private static Mastery mAlacrity;
        private static Mastery mSorcery;
        private static Mastery mDemolitionist;
        private static Mastery mDeadliness;
        private static Mastery mWeaponExpertise;
        private static Mastery mArcaneKnowledge;
        private static Mastery mHavoc;
        private static Mastery mLethality;
        private static Mastery mVampirism;
        private static Mastery mBlast;
        private static Mastery mSunder;
        private static Mastery mArchmage;
        private static Mastery mExecutioner;
        #endregion
        #region Defense Vars
        private static Mastery mSummonersResolve;
        private static Mastery mResistance;
        private static Mastery mHardiness;
        private static Mastery mToughSkin;
        private static Mastery mDurability;
        private static Mastery mVigor;
        private static Mastery mIndomitable;
        private static Mastery mVetransScars;
        private static Mastery mEvasion;
        private static Mastery mBladedArmor;
        private static Mastery mSiegeCommander;
        private static Mastery mInitiator;
        private static Mastery mEnlightenment;
        private static Mastery mHonorGuard;
        private static Mastery mMercenary;
        private static Mastery mJuggernaut;
        #endregion
        #region Utility Vars
        private static Mastery mSummonersInsight;
        private static Mastery mGoodHands;
        private static Mastery mExpandedMind;
        private static Mastery mImprovedRecall;
        private static Mastery mSwiftness;
        private static Mastery mMeditation;
        private static Mastery mScout;
        private static Mastery mGreed;
        private static Mastery mTransmutation;
        private static Mastery mRunicAffinity;
        private static Mastery mWealth;
        private static Mastery mAwareness;
        private static Mastery mSage;
        private static Mastery mStrengthOfSpirit;
        private static Mastery mIntelligence;
        private static Mastery mMastermind;
        #endregion
        #endregion

        #region Tooltip Variables
        private Mastery      tTipMastery        = new Mastery( "tTip" );
        private bool         tTipUp             = false;
        private Font         tTipFont           = new Font( "Microsoft Sans Serif", 8F );
        private string       tTipName           = "";
        private Font         tTipNameFont       = new Font( "Microsoft Sans Serif", 13F );
        private SolidBrush   tTipNameBrush      = new SolidBrush( Color.OrangeRed );
        private string       tTipRank           = "";
        private SolidBrush   tTipRankBrush      = new SolidBrush( Color.LimeGreen );
        private string       tTipReq            = "";
        private SolidBrush   tTipReqBrush       = new SolidBrush( Color.Red );
        private string       tTipLevelData      = "";
        private SolidBrush   tTipLevelDataBrush = new SolidBrush( Color.White );
        private Regex        tTipStringRegex    = new Regex( @"#\w{6}#.*#.*\r\n" );
        private Regex        tTipColorRegex     = new Regex( @"#\w{6}#" );
        private Regex        tTipNameRegex      = new Regex( @"\b#.*#" );
        private Regex        tTipTextRegex      = new Regex( @"\b:#.*\r\n" );
        private Regex        tTipLevelDataRegex = new Regex( @"%f" );
        private List<string> tTipColorText      = new List<string>();
        private List<string> tTipColors         = new List<string>();
        private List<string> tTipWhiteText      = new List<string>();
        #endregion

        private enum Trees { Offense, Defense, Utility }

        public static string Build_Name = "";
        public static string[] returnStrings;

        public BuildEditor()
        {
            InitializeComponent();
            setupData();
            bgwChecker.RunWorkerAsync();
        }

        private void bgwChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            int index = -1;
            int TreeMasteriesIndex = -1;
            List<Mastery> MasteryList = new List<Mastery>();
            List<Label>   LabelList = new List<Label>();
            while ( true )
            {
                foreach( List<Mastery> a in Masteries )
                {
                    foreach ( Mastery m in a )
                    {
                        index = a.IndexOf( m );
                        TreeMasteriesIndex = Masteries.IndexOf( a );
                        #region Get Lists
                        if ( a == offenseMasteries )
                        {
                            MasteryList = offenseMasteries;
                            LabelList   = offenseLabels;
                        } else if ( a == defenseMasteries ) {
                            MasteryList = defenseMasteries;
                            LabelList   = defenseLabels;
                        } else if ( a == utilityMasteries ) {
                            MasteryList = utilityMasteries;
                            LabelList   = utilityLabels;
                        }
                        #endregion
                        if( meetsRequirements( m ) == false || ( PointsRemaining == 0 && m.Level == 0 ) ) 
                        { 
                            LabelList[index].ForeColor = Color.LightGray;
                        } else if ( m.Level == m.MaxLevel ) {
                            LabelList[index].ForeColor = Color.Orange;
                        } else {
                            LabelList[index].ForeColor = Color.LimeGreen;
                        }
                    }
                }
                Thread.Sleep( 200 );
            }
        }

        public static string[] showBox()
        {
            Editor = new BuildEditor();
            labelLists();
            Editor.buildLoad( "00000000000000000\r\n0000000000000000\r\n0000000000000000" );
            Editor.ShowDialog();
            Editor.BackColor = Color.White;
            return returnStrings;
        }

        public static string[] showBox( string name, string info, string buildPoints )
        {
            Editor = new BuildEditor();
            Editor.edtBuildName.Text   = name;
            Editor.edtDescription.Text = info;
            Editor.edtBuildCode.Text   = buildPoints;
            labelLists();
            Editor.buildLoad( buildPoints );
            Editor.ShowDialog();
            return returnStrings;
            //return Build_Name;
        }

        #region Event Handlers
        private void BuildEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( e.CloseReason == CloseReason.UserClosing )
            {
                CancelClicked();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClicked();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            AcceptClicked();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Editor.buildLoad( "00000000000000000\r\n0000000000000000\r\n0000000000000000" );
        }

        private void edtBuildName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AcceptClicked();
            }
            if ( e.KeyCode == Keys.OemQuotes )
            {
                e.SuppressKeyPress = true;
            }
        }

        private void edtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AcceptClicked();
            }
            if ( e.KeyCode == Keys.OemQuotes )
            {
                e.SuppressKeyPress = true;
            }
        }

        private void AcceptClicked()
        {
            returnStrings = new string[3]{ edtBuildName.Text, edtDescription.Text, edtBuildCode.Text };
            Editor.Dispose();
        }

        private void CancelClicked()
        {
            returnStrings = new string[1]{ "Cancel" };
            Editor.Dispose();
        }

        private void MasteryTree_MouseUp(object sender, MouseEventArgs e)
        {
            Point p = new Point( e.X, e.Y );
            bool b = false;
            int index = -1;
            int TreeMasteriesIndex = -1;
            Mastery treeOBJ = null;
            List<Mastery> MasteryList = new List<Mastery>();
            List<Label>   LabelList = new List<Label>();
            foreach( List<Mastery> a in Masteries )
            {
                foreach ( Mastery m in a )
                {
                    if ( m.Rectangle.Contains( p ) )
                    {
                        index = a.IndexOf( m );
                        TreeMasteriesIndex = Masteries.IndexOf( a );
                        #region Get Lists
                        if ( a == offenseMasteries )
                        {
                            MasteryList = offenseMasteries;
                            LabelList   = offenseLabels;
                            treeOBJ     = mOffense;
                        } else if ( a == defenseMasteries ) {
                            MasteryList = defenseMasteries;
                            LabelList   = defenseLabels;
                            treeOBJ     = mDefense;
                        } else if ( a == utilityMasteries ) {
                            MasteryList = utilityMasteries;
                            LabelList   = utilityLabels;
                            treeOBJ     = mUtility;
                        }
                        #endregion
                        if ( PointsRemaining > 0 && meetsRequirements( MasteryList[index] ) && MasteryList[index].Level < MasteryList[index].MaxLevel && e.Button == MouseButtons.Left )
                        {
                            MasteryList[index].Level += 1;
                            TreeMasteries[TreeMasteriesIndex].Level += 1;
                            PointLabels[TreeMasteriesIndex].Text = PointLabels[TreeMasteriesIndex].Tag + TreeMasteries[TreeMasteriesIndex].Level.ToString();
                            PointsRemaining -= 1;
                            Editor.lblPointsRemaining.Text = Editor.lblPointsRemaining.Tag + PointsRemaining.ToString();
                            LabelList[index].Text = MasteryList[index].Level.ToString() + " / " + LabelList[index].Tag.ToString();
                            updateBuildCode();
                        } else if ( PointsRemaining < 30 && MasteryList[index].Level > 0 && e.Button == MouseButtons.Right && wontAffectOtherMasteries( m ) ) {
                            MasteryList[index].Level -= 1;
                            TreeMasteries[TreeMasteriesIndex].Level -= 1;
                            PointLabels[TreeMasteriesIndex].Text = PointLabels[TreeMasteriesIndex].Tag + TreeMasteries[TreeMasteriesIndex].Level.ToString();
                            PointsRemaining += 1;
                            Editor.lblPointsRemaining.Text = Editor.lblPointsRemaining.Tag + PointsRemaining.ToString();
                            LabelList[index].Text = MasteryList[index].Level.ToString() + " / " + LabelList[index].Tag.ToString();
                            updateBuildCode();
                        }
                        if ( m == tTipMastery ) { tooltip( m ); }
                        b = true;
                        break;
                    }
                }
                if ( b ) break;
            }
        }

        private void MasteryTree_MouseMove(object sender, MouseEventArgs e)
        {
            foreach( List<Mastery> a in Masteries )
            {
                foreach ( Mastery m in a )
                {
                    if ( m.Rectangle.Contains( e.Location ) )
                    {
                        if ( tTipUp == false ) // && tTipMastery != m ) 
                        {
                            tooltip( m );
                        }
                    } else  {
                        if ( tTipMastery == m ) 
                        {
                            tTipUp = false;
                            pnlTooltip.Visible = false;
                        }
                    }
                }
            }
        }

        private void tooltip( Mastery m )
        {
            tTipMastery = m;
            #region Name
            tTipName = m.Name;
            if     ( getTreeMastery( m ) == mOffense ) { tTipNameBrush = new SolidBrush( Color.FromArgb( 255, 69, 0 ) ); }
            else if( getTreeMastery( m ) == mDefense ) { tTipNameBrush = new SolidBrush( Color.DeepSkyBlue ); }
            else if( getTreeMastery( m ) == mUtility ) { tTipNameBrush = new SolidBrush( Color.GreenYellow ); }
            #endregion
            #region Rank
            tTipRank = "Rank: " + m.Level.ToString() + "/" + m.MaxLevel.ToString() ;
            if     ( ( PointsRemaining == 0 && m.Level == 0 ) || !meetsRequirements( m ) ) { tTipRankBrush = new SolidBrush( Color.LightGray ); }
            else if( (m.Level / m.MaxLevel) < 1 )                                          { tTipRankBrush = new SolidBrush( Color.LimeGreen ); } 
            else                                                                           { tTipRankBrush = new SolidBrush( Color.Orange    ); }
            #endregion
            #region Requirements
            int i = 0;
            tTipReq = "";
            foreach( Mastery m2 in m.Conditions )
            {
                tTipReq += "Requires " + m.ConditionLevels[i].ToString() + " points in " + m2.Name + ".\r\n";
                i++;
            }
            tTipReq.TrimEnd( "\r\n".ToCharArray() );
            #endregion
            #region Build Data
            if ( tTipStringRegex.IsMatch( m.LevelData ) )
            {
                tTipLevelData = "";
                tTipColorText = new List<string>();
                tTipColors    = new List<string>();
                tTipWhiteText = new List<string>();
                MatchCollection MC = tTipStringRegex.Matches( m.LevelData );
                foreach ( Match match in MC )
                {
                    //MessageBox.Show( "Color: " + color.Match( match.Value ).Value.Trim( '#' ) + "\r\nName: " + name.Match( match.Value ).Value.Trim( '#' ) + "\r\nText: " + text.Match( match.Value ).Value.TrimStart( ":# ".ToCharArray() ) );
                    tTipColors   .Add( tTipColorRegex.Match( match.Value ).Value.Trim( '#' ) );
                    tTipColorText.Add( tTipNameRegex .Match( match.Value ).Value.Trim( '#' ) );
                    tTipWhiteText.Add( tTipTextRegex .Match( match.Value ).Value.TrimStart( ":# ".ToCharArray() ) );
                }
            } else {
                if ( tTipLevelDataRegex.IsMatch(m.LevelData) )
                {
                    string s = m.LevelData;
                    int i2 = 0;
                    foreach ( Match mtch in tTipLevelDataRegex.Matches( s ) )
                    {
                        string r = "";
                        for ( int i3 = 0; i3 < m.MaxLevel; i3++ )
                        {
                            r += m.DataReplace[i2,i3].ToString();
                            if ( i3 != m.MaxLevel - 1 ) { r += " / "; }
                        }
                        s = tTipLevelDataRegex.Replace( s, r, 1, 0 );
                        i2++;
                    }
                    tTipLevelData = s;
                } else {
                    tTipLevelData = m.LevelData;
                }
            }
            #endregion
            #region Panel Size
            pnlTooltip.Width  = m.Width;
            pnlTooltip.Height = m.Height;
            #endregion
            pnlTooltip.Location = getToolTipPoint( m );
            pnlTooltip.Invalidate();
            pnlTooltip.Visible = true;
            tTipUp = true;
        }

        private void pnlTooltip_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            float x = 0;
            float x2 = 0;
            float y = 0;
            SolidBrush b;
            g.Clear( Color.Black );
            g.DrawRectangle(new Pen(Brushes.LightGray, 1), new Rectangle(e.ClipRectangle.X + 3, e.ClipRectangle.Y + 3, e.ClipRectangle.Width - 6, e.ClipRectangle.Height - 6));
            g.DrawString( tTipName, tTipNameFont, tTipNameBrush, new PointF( 4.5F,  5.0F ) );
            g.DrawString( tTipRank,     tTipFont, tTipRankBrush, new PointF( 5.0F, 25.0F ) );
            g.DrawString(  tTipReq,     tTipFont,  tTipReqBrush, new PointF( 5.0F, 37.0F ) );
            if ( tTipReq == "" ) { y = 38F; } else { y = 38F + g.MeasureString( tTipReq, tTipFont ).Height; }
            if ( tTipLevelData == "" )
            {
                x  = 5F;
                g.DrawString( "Improves the following Summoner Spells:", tTipFont, tTipLevelDataBrush, x, y );
                y += 12F;
                if ( tTipMastery == mSummonersWrath ) { x2 = 50; } else if ( tTipMastery == mSummonersResolve ) { x2 = 50; } else if ( tTipMastery == mSummonersInsight ) { x2 = 75; }
                for ( int i = 0; i < tTipColors.Count; i++ ) 
                {
                    b = new SolidBrush( ColorTranslator.FromHtml( "#" + tTipColors[i] ) );
                    g.DrawString( tTipColorText[i], tTipFont, b, x, y );
                    //x += g.MeasureString( tTipColorText[i], tTipFont ).Width;
                    g.DrawString( tTipWhiteText[i], tTipFont, tTipLevelDataBrush, x2, y );
                    y += 12F;
                    x = 5F;
                }
            } else {
                g.DrawString( tTipLevelData, tTipFont, tTipLevelDataBrush, 5F, y );
            }
        }

        private void pnlTooltip_MouseMove(object sender, MouseEventArgs e)
        {
            tTipUp = false;
            pnlTooltip.Visible = false;
        }
        #endregion


        /// <summary>
        /// Sets up all the mastery data needed for tooltips, clicking, and positioning.
        /// </summary>
        private static void setupData()
        {
            Masteries = new List<List<Mastery>>();
            offenseMasteries = new List<Mastery>();
            defenseMasteries = new List<Mastery>();
            utilityMasteries = new List<Mastery>();
            Labels = new List<List<Label>>();
            offenseLabels = new List<Label>();
            defenseLabels = new List<Label>();
            utilityLabels = new List<Label>();
            spacer  = new Point(  64, 74 );
            offense = new Point(  22, 14 );
            defense = new Point( 295, 14 );
            utility = new Point( 568, 14 );
            TreeMasteries = new List<Mastery>();
            mOffense = new Mastery( "Offense" );
            mDefense = new Mastery( "Defense" );
            mUtility = new Mastery( "Utility" );
            TreeMasteries.Add( mOffense );
            TreeMasteries.Add( mDefense );
            TreeMasteries.Add( mUtility );
            Mastery[] offensePoints = new Mastery[] { mOffense };
            Mastery[] defensePoints = new Mastery[] { mDefense };
            Mastery[] utilityPoints = new Mastery[] { mUtility };
            #region Offensive
                #region Summoners Wrath
                mSummonersWrath = 
                        new Mastery
                        ( 
                            "Summoner's Wrath", 
                            treePoint( 0, 0, Trees.Offense ),
                            1,
                            (
                                "Improves the following Summoner Spells:\r\n\r\n" +
                                "#FFFF00#Exhaust:# Reduces target's Magic Resist and Armor by 10\r\n" +
                                "#FFFF00#Ignite:# Increases Ability Power and Attack Damage by 5 while on cooldown\r\n" +
                                "#FFFF00#Surge:# Increases Ability Power and Attack Speed gained by 10%\r\n" +
                                "#FFFF00#Ghost:# Increases Movement Speed bonus to 35%\r\n"
                            ),
                            null,
                            null,
                            null,
                            0,
                            390,
                            105
                        );
                #endregion
                #region Brute Force
                    mBruteForce =
                        new Mastery
                        (
                            "Brute Force",
                            treePoint( 1, 0, Trees.Offense ),
                            3,
                            "+%f Attack Damage",
                            new double[,] { {1, 2, 3} },
                            null,
                            null,
                            0,
                            200,
                            60
                        );
                #endregion
                #region Mental Force
                    mMentalForce =
                        new Mastery
                        (
                            "Mental Force",
                            treePoint( 2, 0, Trees.Offense ),
                            4,
                            "+%f Ability Power",
                            new double[,] { { 1, 2, 3, 4 } },
                            null,
                            null,
                            0,
                            200,
                            60
                        );
                #endregion
                #region Butcher
                    mButcher =
                        new Mastery
                        (
                            "Butcher",
                            treePoint( 3, 0, Trees.Offense ),
                            2,
                            "Basic attacks deal %f bonus damage to minions and monsters",
                            new double[,] { { 2, 4 } },
                            null,
                            null,
                            0,
                            330,
                            60
                        );
                #endregion
                #region Alacrity
                    mAlacrity =
                        new Mastery
                        (
                            "Alacrity",
                            treePoint( 1, 1, Trees.Offense ),
                            4,
                            "+%f% Attack Speed",
                            new double[,] { { 1, 2, 3, 4 } },
                            offensePoints,
                            new int[] { 4 },
                            1,
                            200,
                            70
                        );
                #endregion
                #region Sorcery
                    mSorcery =
                        new Mastery
                        (
                            "Sorcery",
                            treePoint( 2, 1, Trees.Offense ),
                            4,
                            "+%f% Cooldown Reduction",
                            new double[,] { { 1, 2, 3, 4 } },
                            offensePoints,
                            new int[] { 4 },
                            1,
                            200,
                            70
                        );
                #endregion
                #region Demolitionist
                    mDemolitionist =
                        new Mastery
                        (
                            "Demolitionist",
                            treePoint( 3, 1, Trees.Offense ),
                            1,
                            "Basic attacks deal 10 bonus damage to towers",
                            null,
                            offensePoints,
                            new int[] { 4 },
                            1,
                            245,
                            70
                        );
                #endregion
                #region Deadliness
                    mDeadliness =
                        new Mastery
                        (
                            "Deadliness",
                            treePoint( 0, 2, Trees.Offense ),
                            4,
                            "+%f Attack Damage\r\n" +
                            "(+%f Attack Damage at champion level 18)",
                            new double[,] { { 0.125, 0.25, 0.375, 0.5 }, { 2.25, 4.5, 6.75, 9 } },
                            offensePoints,
                            new int[] { 8 },
                            2,
                            300,
                            85
                        );
                #endregion
                #region Weapon Expertise
                    mWeaponExpertise =
                        new Mastery
                        (
                            "Weapon Expertise",
                            treePoint( 1, 2, Trees.Offense ),
                            1,
                            "+10% Armor Penetration",
                            null,
                            new Mastery[] { mOffense, mAlacrity },
                            new int[] { 8, 4 },
                            2,
                            200,
                            85
                        );
                #endregion
                #region Arcane Knowledge
                    mArcaneKnowledge =
                        new Mastery
                        (
                            "Arcane Knowledge",
                            treePoint( 2, 2, Trees.Offense ),
                            1,
                            "+10% Magic Penetration",
                            null,
                            new Mastery[] { mOffense, mSorcery },
                            new int[] { 8, 4 },
                            2,
                            200,
                            85
                        );
                #endregion
                #region Havoc
                    mHavoc =
                        new Mastery
                        (
                            "Havoc",
                            treePoint( 3, 2, Trees.Offense ),
                            3,
                            "Increases damage dealt by %f%",
                            new double[,] { { 0.5, 1, 1.5 } },
                            offensePoints,
                            new int[] { 8 },
                            2,
                            215,
                            70
                        );
                #endregion
                #region Lethality
                    mLethality =
                        new Mastery
                        (
                            "Lethality",
                            treePoint( 0, 3, Trees.Offense ),
                            1,
                            "10% Critical Strike Damage",
                            null,
                            new Mastery[] { mOffense, mDeadliness },
                            new int[] { 12, 4 },
                            3,
                            200,
                            85
                        );
                #endregion
                #region Vampirism
                    mVampirism = 
                        new Mastery
                        (
                            "Vampirism",
                            treePoint( 1, 3, Trees.Offense ),
                            3,
                            "%f% Life Steal",
                            new double[,] { { 1, 2, 3 } },
                            offensePoints,
                            new int[] { 12 },
                            3,
                            200,
                            70
                        );
                #endregion
                #region Blast
                    mBlast =
                        new Mastery
                        (
                            "Blast",
                            treePoint( 2, 3, Trees.Offense ),
                            4,
                            (
                                "+%f Ability Power per level\r\n" +
                                "(%f Ability Power at champion level 18)"
                            ),
                            new double[,] { { 0.25, 0.5, 0.75, 1 }, { 4.5, 9, 13.5, 18 } },
                            offensePoints,
                            new int[] { 12 },
                            3,
                            275,
                            82
                        );
                #endregion
                #region Sunder
                    mSunder =
                        new Mastery
                        (
                            "Sunder",
                            treePoint( 1, 4, Trees.Offense ),
                            3,
                            "+%f Armor Penetration",
                            new double[,] { { 2, 4, 6 } },
                            offensePoints,
                            new int[] { 16 },
                            4,
                            200,
                            70
                        );
                #endregion
                #region Archmage
                    mArchmage =
                        new Mastery
                        (
                            "Archmage",
                            treePoint( 2, 4, Trees.Offense ),
                            4,
                            "Increases your Ability Power %f%",
                            new double[,] { { 1.25, 2.5, 3.75, 5 } },
                            offensePoints,
                            new int[] { 16 },
                            4,
                            260,
                            70
                        );
                #endregion
                #region Executioner
                    mExecutioner =
                        new Mastery
                        (
                            "Executioner",
                            treePoint( 1, 5, Trees.Offense ),
                            1,
                            "Increases damage dealt by 6% to targets below 40% Health",
                            null,
                            offensePoints,
                            new int[] { 20 },
                            5,
                            305,
                            75
                        );
                #endregion
                #region Add Items to Lists
                    offenseMasteries.Add( mSummonersWrath );
                    offenseMasteries.Add( mBruteForce );
                    offenseMasteries.Add( mMentalForce );
                    offenseMasteries.Add( mButcher );
                    offenseMasteries.Add( mAlacrity );
                    offenseMasteries.Add( mSorcery );
                    offenseMasteries.Add( mDemolitionist );
                    offenseMasteries.Add( mDeadliness );
                    offenseMasteries.Add( mWeaponExpertise );
                    offenseMasteries.Add( mArcaneKnowledge );
                    offenseMasteries.Add( mHavoc );
                    offenseMasteries.Add( mLethality );
                    offenseMasteries.Add( mVampirism );
                    offenseMasteries.Add( mBlast );
                    offenseMasteries.Add( mSunder );
                    offenseMasteries.Add( mArchmage );
                    offenseMasteries.Add( mExecutioner );
                    Masteries.Add( offenseMasteries );
                #endregion
            #endregion
            #region Defensive
                #region Summoners Resolve
                    mSummonersResolve =
                        new Mastery
                        (
                            "Summoner's Resolve",
                            treePoint( 0, 0, Trees.Defense ),
                            1,
                            (
                                "Improves the following Summoner Spells:\r\n\r\n" +
                                "#FFFF00#Revive:# Grants a massive Movement Speed boost for a short duration upon reviving\r\n" +
                                "#FFFF00#Cleanse:# Increases duration of disable reduction by 1 second\r\n" +
                                "#FFFF00#Heal:# Increases Health restored by 15%\r\n" +
                                "#FFFF00#Smite:# Grants 10 bonus gold on use\r\n" +
                                "#FFFF00#Garrison:# Allied Garrisoned turrets deal 50% splash damage"
                            ),
                            null,
                            null,
                            null,
                            0,
                            427,
                            105
                        );
                #endregion
                #region Resistance
                    mResistance =
                        new Mastery
                        (
                            "Resistance",
                            treePoint( 1, 0, Trees.Defense ),
                            3,
                            "+%f Magic Resist",
                            new double[,] { { 2, 4, 6 } },
                            null,
                            null,
                            0,
                            200,
                            60
                        );
                #endregion
                #region Hardiness
                    mHardiness =
                        new Mastery
                        (
                            "Hardiness",
                            treePoint( 2, 0, Trees.Defense ),
                            3,
                            "+%f Armor",
                            new double[,] { { 2, 4, 6 } },
                            null,
                            null,
                            0,
                            200,
                            60
                        );
                #endregion
                #region Tough Skin
                    mToughSkin =
                        new Mastery
                        (
                            "Tough Skin",
                            treePoint( 3, 0, Trees.Defense ),
                            2,
                            "Reduces damage taken from minions and monsters by %f",
                            new double[,] { { 1, 2 } },
                            null,
                            null,
                            0,
                            310,
                            60
                        );
                #endregion
                #region Durability
                    mDurability =
                        new Mastery
                        (
                            "Durability",
                            treePoint( 1, 1, Trees.Defense ),
                            4,
                            "+%f Health per level\r\n" +
                            "(%f Health at champion level 18)",
                            new double[,] { { 1.5, 3, 4.5, 6 }, { 27, 64, 81, 108 } },
                            defensePoints,
                            new int[] { 4 },
                            1,
                            250,
                            85
                        );
                #endregion
                #region Vigor
                    mVigor =
                        new Mastery
                        (
                            "Vigor",
                            treePoint( 2, 1, Trees.Defense ),
                            3,
                            "+%f Health Regen per 5 seconds",
                            new double[,] { { 1, 2, 3 } },
                            defensePoints,
                            new int[] { 4 },
                            1,
                            200,
                            70
                        );
                #endregion
                #region Indomitable
                    mIndomitable =
                        new Mastery
                        (
                            "Indomitable",
                            treePoint( 0, 2, Trees.Defense ),
                            2,
                            "Reduces incoming damage by %f",
                            new double[,] { { 1, 2 } },
                            defensePoints,
                            new int[] { 8 },
                            2,
                            200,
                            70
                        );
                #endregion
                #region Vetrans Scars
                    mVetransScars =
                        new Mastery
                        (
                            "Vetran's Scars",
                            treePoint( 1, 2, Trees.Defense ),
                            1,
                            "+30 Health",
                            null,
                            new Mastery[] { mDefense, mDurability },
                            new int[] { 8, 4 },
                            2,
                            200,
                            85
                        );
                #endregion
                #region Evasion
                    mEvasion =
                        new Mastery
                        (
                            "Evasion",
                            treePoint( 2, 2, Trees.Defense ),
                            3,
                            "Reduces the damage taken from area effect abilities by %f%",
                            new double[,] { { 1, 2, 3 } },
                            defensePoints,
                            new int[] { 8 },
                            2,
                            330,
                            70
                        );
                #endregion
                #region Bladed Armor
                    mBladedArmor =
                        new Mastery
                        (
                            "Bladed Armor",
                            treePoint( 3, 2, Trees.Defense ),
                            1,
                            "Returns 6 damage aginst minion and monster attacks",
                            null,
                            new Mastery[] { mDefense, mToughSkin },
                            new int[] { 8, 2 },
                            2,
                            280,
                            85
                        );
                #endregion
                #region Siege Commander
                    mSiegeCommander =
                        new Mastery
                        (
                            "Siege Commander",
                            treePoint( 0, 3, Trees.Defense ),
                            1,
                            "Reduces the Armor of nearby towers by 10 (does not stack)",
                            null,
                            defensePoints,
                            new int[] { 12 },
                            3,
                            310,
                            70
                        );
                #endregion
                #region Initiator
                    mInitiator =
                        new Mastery
                        (
                            "Initiator",
                            treePoint( 1, 3, Trees.Defense ),
                            3,
                            "Increases Movement Speed by %f% when above 70% Health",
                            new double[,] { { 1, 2, 3 } },
                            defensePoints,
                            new int[] { 12 },
                            3,
                            340,
                            70
                        );
                #endregion
                #region Enlightenment
                    mEnlightenment =
                        new Mastery
                        (
                            "Enlightenment",
                            treePoint( 2, 3, Trees.Defense ),
                            3,
                            "+%f Cooldown Reduction per level\r\n" +
                            "(+%f Cooldown Reduction at champion level 18)",
                            new double[,] { { 0.15, 0.3, 0.45 }, { 2.7, 5.4, 8.1 } },
                            defensePoints,
                            new int[] { 12 },
                            3,
                            300,
                            85
                        );
                #endregion
                #region Honor Guard
                    mHonorGuard =
                        new Mastery
                        (
                            "Honor Guard",
                            treePoint( 1, 4, Trees.Defense ),
                            3,
                            "Reduces damage taken by %f%",
                            new double[,] { { 0.5, 1, 1.5 } },
                            defensePoints,
                            new int[] { 16 },
                            4,
                            210,
                            70
                        );
                #endregion
                #region Mercenary
                    mMercenary =
                        new Mastery
                        (
                            "Mercenary",
                            treePoint( 2, 4, Trees.Defense ),
                            3,
                            "Gain %f bonus gold for champion kills and assists\r\n" +
                            "(50% reduced effect on the Crystal Scar)",
                            new double[,] { { 8, 16, 24 } },
                            defensePoints,
                            new int[] { 16 },
                            4,
                            300,
                            85
                        );
                #endregion
                #region Juggernaut
                    mJuggernaut =
                        new Mastery
                        (
                            "Juggernaut",
                            treePoint( 1, 5, Trees.Defense ),
                            1,
                            "Increases your maximum Health by 3% and reduces\r\n" + 
                            "the duration of incoming disables by 10%",
                            null,
                            defensePoints,
                            new int[] { 20 },
                            5,
                            270,
                            85
                        );
                #endregion
                #region Add Items to Lists
                    defenseMasteries.Add( mSummonersResolve );
                    defenseMasteries.Add( mResistance );
                    defenseMasteries.Add( mHardiness );
                    defenseMasteries.Add( mToughSkin );
                    defenseMasteries.Add( mDurability );
                    defenseMasteries.Add( mVigor );
                    defenseMasteries.Add( mIndomitable );
                    defenseMasteries.Add( mVetransScars );
                    defenseMasteries.Add( mEvasion );
                    defenseMasteries.Add( mBladedArmor );
                    defenseMasteries.Add( mSiegeCommander );
                    defenseMasteries.Add( mInitiator );
                    defenseMasteries.Add( mEnlightenment );
                    defenseMasteries.Add( mHonorGuard );
                    defenseMasteries.Add( mMercenary );
                    defenseMasteries.Add( mJuggernaut );
                    Masteries.Add( defenseMasteries );
                #endregion
            #endregion
            #region Utility
                #region Summoners Insight
                    mSummonersInsight =
                        new Mastery
                        (
                            "Summoner's Insight",
                            treePoint( 0, 0, Trees.Utility ),
                            1,
                            (
                                "Improves the following Summoner Spells\r\n\r\n" +
                                "#FFFF00#Teleport:# Reduces cast time by 1 second\r\n" +
                                "#FFFF00#Promote:# Increases promoted minion's bonus defensive stats by 15%\r\n" +
                                "#FFFF00#Flash:# Reduces cooldown by 15 seconds\r\n" +
                                "#FFFF00#Clarity:# Increases Mana restored by 20%\r\n" +
                                "#FFFF00#Clairvoyance:# Increases duration by 2\r\n"
                            ),
                            null,
                            null,
                            null,
                            0,
                            375,
                            117
                        );
                #endregion
                #region Good Hands
                    mGoodHands =
                        new Mastery
                        (
                            "Good Hands",
                            treePoint( 1, 0, Trees.Utility ),
                            3,
                            "Reduces time spend dead by %f%",
                            new double[,] { { 4, 7, 10 } },
                            null,
                            null,
                            0,
                            215,
                            60
                        );
                #endregion
                #region Expanded Mind
                    mExpandedMind =
                        new Mastery
                        (
                            "Expanded Mind",
                            treePoint( 2, 0, Trees.Utility ),
                            3,
                            "+%f Mana per level\r\n" +
                            "(+%f Mana at champion level 18)\r\n" +
                            "or +%f Energy",
                            new double[,] { { 4, 8, 12 }, { 72, 144, 216 }, { 4, 7, 10 } },
                            null,
                            null,
                            0,
                            230,
                            85
                        );
                #endregion
                #region Improved Recall
                    mImprovedRecall =
                        new Mastery
                        (
                            "Improved Recall",
                            treePoint( 3, 0,  Trees.Utility ),
                            1,
                            "Reduces the cast time of Recall by 1 second\r\n" + 
                            "and enhanced Recall by 0.5 seconds",
                            null,
                            null,
                            null,
                            0,
                            240,
                            70
                        );
                #endregion
                #region Swiftness
                    mSwiftness =
                        new Mastery
                        (
                            "Swiftness",
                            treePoint( 1, 1, Trees.Utility ),
                            4,
                            "+%f% Movement Speed",
                            new double[,] { { 0.5, 1, 1.5, 2 } },
                            utilityPoints,
                            new int[] { 4 },
                            1,
                            200,
                            70
                        );
                #endregion
                #region Meditation
                    mMeditation =
                        new Mastery
                        (
                            "Meditation",
                            treePoint( 2, 1, Trees.Utility ),
                            3,
                            "+%f Mana Regen per 5 seconds",
                            new double[,] { { 1, 2, 3 } },
                            new Mastery[] { mUtility, mExpandedMind },
                            new int[] { 4, 3 },
                            1,
                            200,
                            85
                        );
                #endregion
                #region Scout
                    mScout =
                        new Mastery
                        (
                            "Scout",
                            treePoint( 3, 1, Trees.Utility ),
                            1,
                            "Increase vision range of wards by 5%",
                            null,
                            utilityPoints,
                            new int[] { 4 },
                            1,
                            200,
                            70
                        );
                #endregion
                #region Greed
                    mGreed =
                        new Mastery
                        (
                            "Greed",
                            treePoint( 1, 2, Trees.Utility ),
                            4,
                            "Gain an additional %f gold every 10 seconds",
                            new double[,] { { 0.5, 1, 1.5, 2 } },
                            utilityPoints,
                            new int[] { 8 },
                            2,
                            290,
                            70
                        );
                #endregion
                #region Transmutation
                    mTransmutation =
                        new Mastery
                        (
                            "Transmutation",
                            treePoint( 2, 2, Trees.Utility ),
                            3,
                            "+%f% Spell Vamp",
                            new double[,] { { 1, 2, 3 } },
                            utilityPoints,
                            new int[] { 8 },
                            2,
                            200,
                            70
                        );
                #endregion
                #region Runic Affinity
                    mRunicAffinity =
                        new Mastery
                        (
                            "Runic Affinity",
                            treePoint( 3, 2, Trees.Utility ),
                            1,
                            "Increases the duration of shrine, relic,\r\n" + 
                            "quest, and neutral monster buffs by 20%",
                            null,
                            utilityPoints,
                            new int[] { 8 },
                            2,
                            210,
                            85
                        );
                #endregion
                #region Wealth
                    mWealth =
                        new Mastery
                        (
                            "Wealth",
                            treePoint( 1, 3, Trees.Utility ),
                            2,
                            "Increases starting gold by %f",
                            new double[,] { { 20, 40 } },
                            new Mastery[] { mUtility, mGreed },
                            new int[] { 12, 4 },
                            3,
                            200,
                            85
                        );
                #endregion
                #region Awareness
                    mAwareness =
                        new Mastery
                        (
                            "Awareness",
                            treePoint( 2, 3, Trees.Utility ),
                            4,
                            "Increases experience gained by %f%",
                            new double[,] { { 1.25, 2.5, 3.75, 5 } },
                            utilityPoints,
                            new int[] { 12 },
                            3,
                            275,
                            70
                        );
                #endregion
                #region Sage
                    mSage =
                        new Mastery
                        (
                            "Sage",
                            treePoint( 3, 3, Trees.Utility ),
                            1,
                            "Gain 40 bonus experience on champion kills and assists\r\n" +
                            "(50% reduced effect on the Crystal Scar)",
                            null,
                            utilityPoints,
                            new int[] { 12 },
                            3,
                            290,
                            85
                        );
                #endregion
                #region Strength of Spirit
                    mStrengthOfSpirit =
                        new Mastery
                        (
                            "Strength of Spirit",
                            treePoint( 1, 4, Trees.Utility ),
                            3,
                            "Increases Health regen per 5 seconds\r\n" + 
                            "by %f% of maximum mana",
                            new double[,] { { 0.4, 0.7, 1 } },
                            utilityPoints,
                            new int[] { 16 },
                            4,
                            200,
                            85
                        );
                #endregion
                #region Intelligence
                    mIntelligence =
                        new Mastery
                        (
                            "Intelligence",
                            treePoint( 2, 4, Trees.Utility ),
                            3,
                            "+%f% Cooldown Reduction",
                            new double[,] { { 2, 4, 6 } },
                            utilityPoints,
                            new int[] { 16 },
                            4,
                            200,
                            70
                        );
                #endregion
                #region Mastermind
                    mMastermind =
                        new Mastery
                        (
                            "Mastermind",
                            treePoint( 2, 5, Trees.Utility ),
                            1,
                            "Reduced the cooldown of your Summoner Spells by 15%",
                            null,
                            utilityPoints,
                            new int[] { 20 },
                            5,
                            290,
                            75
                        );
                #endregion
                #region Add Items to Lists
                    utilityMasteries.Add( mSummonersInsight );
                    utilityMasteries.Add( mGoodHands );
                    utilityMasteries.Add( mExpandedMind );
                    utilityMasteries.Add( mImprovedRecall );
                    utilityMasteries.Add( mSwiftness );
                    utilityMasteries.Add( mMeditation );
                    utilityMasteries.Add( mScout );
                    utilityMasteries.Add( mGreed );
                    utilityMasteries.Add( mTransmutation );
                    utilityMasteries.Add( mRunicAffinity );
                    utilityMasteries.Add( mWealth );
                    utilityMasteries.Add( mAwareness );
                    utilityMasteries.Add( mSage );
                    utilityMasteries.Add( mStrengthOfSpirit );
                    utilityMasteries.Add( mIntelligence );
                    utilityMasteries.Add( mMastermind );
                    Masteries.Add( utilityMasteries );
                #endregion
            #endregion
        }

        /// <summary>
        /// Adds all the labels on the form to lists, so that they can be modified for the corrosponding mastery.
        /// </summary>
        private static void labelLists()
        {
            #region Labels
                #region Offense
                    offenseLabels.Add( Editor.lblSummonersWrath );
                    offenseLabels.Add( Editor.lblBruteForce );
                    offenseLabels.Add( Editor.lblMentalForce );
                    offenseLabels.Add( Editor.lblButcher );
                    offenseLabels.Add( Editor.lblAlacrity );
                    offenseLabels.Add( Editor.lblSorcery );
                    offenseLabels.Add( Editor.lblDemolitionist );
                    offenseLabels.Add( Editor.lblDeadlieness );
                    offenseLabels.Add( Editor.lblWeaponExpertise );
                    offenseLabels.Add( Editor.lblArcaneKnowledge );
                    offenseLabels.Add( Editor.lblHavoc );
                    offenseLabels.Add( Editor.lblLethality );
                    offenseLabels.Add( Editor.lblVampirism );
                    offenseLabels.Add( Editor.lblBlast );
                    offenseLabels.Add( Editor.lblSunder );
                    offenseLabels.Add( Editor.lblArchmage );
                    offenseLabels.Add( Editor.lblExecutioner );
                    Labels.Add( offenseLabels );
                #endregion
                #region Defense
                    defenseLabels.Add( Editor.lblSummonersResolve );
                    defenseLabels.Add( Editor.lblResistance );
                    defenseLabels.Add( Editor.lblHardiness );
                    defenseLabels.Add( Editor.lblToughSkin );
                    defenseLabels.Add( Editor.lblDurability );
                    defenseLabels.Add( Editor.lblVigor );
                    defenseLabels.Add( Editor.lblIndomitable );
                    defenseLabels.Add( Editor.lblVetransScars );
                    defenseLabels.Add( Editor.lblEvasion );
                    defenseLabels.Add( Editor.lblBladedArmor );
                    defenseLabels.Add( Editor.lblSiegeCommander );
                    defenseLabels.Add( Editor.lblInitiator );
                    defenseLabels.Add( Editor.lblEnlightenment );
                    defenseLabels.Add( Editor.lblHonorGuard );
                    defenseLabels.Add( Editor.lblMercenary );
                    defenseLabels.Add( Editor.lblJuggernaut );
                    Labels.Add( defenseLabels );
                #endregion
                #region Utility
                    utilityLabels.Add( Editor.lblSummonersInsight );
                    utilityLabels.Add( Editor.lblGoodHands );
                    utilityLabels.Add( Editor.lblExpandedMind );
                    utilityLabels.Add( Editor.lblImprovedRecall );
                    utilityLabels.Add( Editor.lblSwiftness );
                    utilityLabels.Add( Editor.lblMeditation );
                    utilityLabels.Add( Editor.lblScout );
                    utilityLabels.Add( Editor.lblGreed );
                    utilityLabels.Add( Editor.lblTransmutation );
                    utilityLabels.Add( Editor.lblRunicAffinity );
                    utilityLabels.Add( Editor.lblWealth );
                    utilityLabels.Add( Editor.lblAwareness );
                    utilityLabels.Add( Editor.lblSage );
                    utilityLabels.Add( Editor.lblStrengthOfSpirit );
                    utilityLabels.Add( Editor.lblIntelligence );
                    utilityLabels.Add( Editor.lblMastermind );
                #endregion
            Labels.Add( offenseLabels );
            Labels.Add( defenseLabels );
            Labels.Add( utilityLabels );
            PointLabels = new List<Label>();
            PointLabels.Add( Editor.lblOffensePoints );
            PointLabels.Add( Editor.lblDefensePoints );
            PointLabels.Add( Editor.lblUtilityPoints );
            #endregion
        }

        private static Point treePoint( int offsetX, int offsetY, Trees t )
        {
            switch ( t )
            {
                case Trees.Offense:
                    return new Point ( offense.X + ( spacer.X * offsetX ), offense.Y + ( spacer.Y * offsetY ) );
                case Trees.Defense:
                    return new Point ( defense.X + ( spacer.X * offsetX ), defense.Y + ( spacer.Y * offsetY ) );
                case Trees.Utility:
                    return new Point ( utility.X + ( spacer.X * offsetX ), utility.Y + ( spacer.Y * offsetY ) );
                default:
                    return new Point ( offense.X + ( spacer.X * offsetX ), offense.Y + ( spacer.Y * offsetY ) );
            }
        }

        private static Boolean meetsRequirements( Mastery m )
        {
            int index = -1;
            foreach ( Mastery m2 in m.Conditions )
            {
                index = m.Conditions.IndexOf( m2 );
                if ( m2.Level < m.ConditionLevels[index] ) 
                {
                    return false;
                }
            }
            return true;
        }

        private static Point getToolTipPoint ( Mastery m ) 
        {
            Point topLeft     = new Point( Editor.MasteryTree.Location.X + m.Rectangle.X + m.Rectangle.Width, Editor.MasteryTree.Location.Y + m.Rectangle.Y + m.Rectangle.Height );
            Point bottomRight = new Point( Editor.MasteryTree.Location.X + m.Rectangle.X + m.Rectangle.Width + m.Width, Editor.MasteryTree.Location.Y + m.Rectangle.Y + m.Rectangle.Height + m.Height );
            Point rPoint      = topLeft;
            if ( bottomRight.X >= Editor.Width  ) { rPoint.X = rPoint.X - Editor.pnlTooltip.Width  - m.Rectangle.Width;  }
            if ( bottomRight.Y >= Editor.Height ) { rPoint.Y = rPoint.Y - Editor.pnlTooltip.Height - m.Rectangle.Height; }
            return rPoint;
        }

        private static void updateBuildCode()
        {
            string s = "";
            foreach( List<Mastery> a in Masteries )
            {
                foreach ( Mastery m in a )
                {
                    s += m.Level.ToString();
                }
                s += "\r\n";
            }
            Editor.edtBuildCode.Text = s;
        }

        private void buildLoad( string s )
        {
            int i = 0;
            int count = 0;
            int total = 0;
            Regex regex = new Regex( "\r?\n" );
            string offenseString = regex.Split(s)[0];
            string defenseString = regex.Split(s)[1];
            string utilityString = regex.Split(s)[2];
            foreach( char c in offenseString.ToCharArray() )
            {
                offenseMasteries[i].Level = Convert.ToInt32( c.ToString() );
                offenseLabels[i].Text = offenseMasteries[i].Level + " / " + offenseMasteries[i].MaxLevel;
                count += offenseMasteries[i].Level;
                i++;
            }
            mOffense.Level = count;
            total += count;
            count = 0;
            i = 0;
            foreach( char c in defenseString.ToCharArray() )
            {
                defenseMasteries[i].Level = Convert.ToInt32( c.ToString() );
                defenseLabels[i].Text = defenseMasteries[i].Level + " / " + defenseMasteries[i].MaxLevel;
                count += defenseMasteries[i].Level;
                i++;
            }
            mDefense.Level = count;
            total += count;
            count = 0;
            i = 0;
            foreach( char c in utilityString.ToCharArray() )
            {
                utilityMasteries[i].Level = Convert.ToInt32( c.ToString() );
                utilityLabels[i].Text = utilityMasteries[i].Level + " / " + utilityMasteries[i].MaxLevel;
                count += utilityMasteries[i].Level;
                i++;
            }
            mUtility.Level = count;
            total += count;
            Editor.lblOffensePoints.Text = Editor.lblOffensePoints.Tag + mOffense.Level.ToString();
            Editor.lblDefensePoints.Text = Editor.lblDefensePoints.Tag + mDefense.Level.ToString();
            Editor.lblUtilityPoints.Text = Editor.lblUtilityPoints.Tag + mUtility.Level.ToString();
            Editor.lblPointsRemaining.Text = Editor.lblPointsRemaining.Tag + ( 30 - total ).ToString();
            PointsRemaining = 30 - total;
        }

        private bool wontAffectOtherMasteries( Mastery compare )
        {
            List<Mastery> tree = getTree( compare );
            Mastery mTree = getTreeMastery( compare );
            int index = 0;
            int count = pointsInTree( tree );
            foreach ( Mastery m in tree )
            {
                if ( m.Conditions.Count > 0 && m.ConditionLevels != null && m.Level > 0 && m != compare )
                {
                    if ( m.Conditions.Contains( mTree ) )
                    {
                        index = m.Conditions.IndexOf( mTree );
                        //MessageBox.Show( "Previous Row Count:" + ( getPreviousRowCount( m ) - 1 ).ToString() + "\r\nRequired Tree Level:" + m.ConditionLevels[index].ToString() );
                        if( (mTree.Level - 1 ) < m.ConditionLevels[index] )
                        {
                            return false;
                        } else if( ( getPreviousRowCount( m ) - 1 ) < m.ConditionLevels[index] && m.Row > compare.Row ) {
                            return false;
                        }
                    } else if ( m.Conditions.Contains( compare ))
                    {
                        index = m.Conditions.IndexOf( compare );
                        if( (compare.Level - 1) < m.ConditionLevels[index] )
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private int getPreviousRowCount( Mastery m )
        {
            int r = 0;
            foreach ( Mastery m2 in getTree( m ) )
            {
                if ( m2.Row < m.Row )
                {
                    r += m2.Level;
                }
            }
            return r;
        }

        private List<Mastery> getTree( Mastery m )
        {
            if( offenseMasteries.Contains( m ) ){ return offenseMasteries; }
            if( defenseMasteries.Contains( m ) ){ return defenseMasteries; }
            if( utilityMasteries.Contains( m ) ){ return utilityMasteries; }
            return null;
        }

        private Mastery getTreeMastery( Mastery m )
        {
            if( offenseMasteries.Contains( m ) ){ return mOffense; }
            if( defenseMasteries.Contains( m ) ){ return mDefense; }
            if( utilityMasteries.Contains( m ) ){ return mUtility; }
            return null;
        }

        private int pointsInTree( Trees t )
        {
            int i = 0;
            switch ( t )
            {
                case Trees.Offense:
                    foreach ( Mastery m in offenseMasteries )
                    {
                        i += m.Level;
                    }
                    return i;
                case Trees.Defense:
                    foreach ( Mastery m in defenseMasteries )
                    {
                        i += m.Level;
                    }
                    return i;
                case Trees.Utility:
                    foreach ( Mastery m in utilityMasteries )
                    {
                        i += m.Level;
                    }
                    return i;
                default:
                    return -1;
            }
        }

        private int pointsInTree( Mastery m )
        {
            int i = 0;
            List<Mastery> list = new List<Mastery>();
            if ( m == mOffense ) list = offenseMasteries;
            if ( m == mDefense ) list = defenseMasteries;
            if ( m == mUtility ) list = utilityMasteries;

            foreach ( Mastery m2 in list )
            {
                i += m2.Level;
            }
            return i;
        }

        private int pointsInTree( List<Mastery> m )
        {
            int i = 0;
            foreach ( Mastery m2 in m )
            {
                i += m2.Level;
            }
            return i;
        }
    }

    class Mastery
    {
        private string    mName;
        private string    mLevelData;
        private ArrayList mConditions;
        private int[]     mConditionNum;
        private double[,] mReplace;
        private int       mMaxLevel;
        private int       mLevel;
        private int       mRow;
        private int       mWidth;
        private int       mHeight;
        private Rectangle mRect;

        public Mastery( string name, Point rectPosition, int maxLevel, string levelData, double[,] Replace, Mastery[] masteries, int[] levels, int row, int width, int height )
        {
            mName         = name;
            mRect         = new Rectangle( rectPosition.X, rectPosition.Y, 48, 48 );
            mMaxLevel     = maxLevel;
            mLevelData    = levelData;
            mLevel        = 0;
            mConditions   = new ArrayList();
            mReplace      = Replace;
            mConditionNum = levels;
            mRow          = row;
            mWidth        = width;
            mHeight       = height;
            if ( masteries != null ) foreach ( Mastery m in masteries ) { mConditions.Add( m ); }
        }

        // Special set up for a 'tree' mastery
        public Mastery( string name )
        {
            mName         = name;
            mRect         = new Rectangle();
            mMaxLevel     = 30;
            mLevelData    = "";
            mLevel        = 0;
            mConditions   = new ArrayList();
            mReplace      = new double[0,0];
        }

        public string    Name            {get{ return mName;         }}
        public Rectangle Rectangle       {get{ return mRect;         }}
        public ArrayList Conditions      {get{ return mConditions;   }}
        public int[]     ConditionLevels {get{ return mConditionNum; }}
        public int       MaxLevel        {get{ return mMaxLevel;     }}
        public int       Height          {get{ return mHeight;       }}
        public int       Width           {get{ return mWidth;        }}
        public int       Row             {get{ return mRow;          }}
        public int       Level           {get{ return mLevel;        } set{ mLevel = value; }}
        public string    LevelData       {get{ return mLevelData;    }}
        public double[,] DataReplace     {get{ return mReplace;      }}
    }
}
