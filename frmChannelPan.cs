using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViPER4WindowsBin.UIControls;

namespace ViPER4WindowsBin
{
    public class FrmChannelPan : Form
    {
        private float m_rChannelPan;
        private readonly IContainer components;
        private Label label_Left;
        private Label label_Right;
        private HSlider hSlider_Pan;
        private SingleButton singleButton_Center;
        private Label label_Value;

        public float ChannelPan
        {
            get => m_rChannelPan;
            set
            {
                m_rChannelPan = value;
                hSlider_Pan.PositionFloat = (float)(m_rChannelPan * 0.5 + 0.5);
            }
        }

        public FrmChannelPan()
        {
            InitializeComponent();
            Text = GlobalMessages.CHANNEL_PAN;
            label_Left.Text = GlobalMessages.LEFT;
            label_Right.Text = GlobalMessages.RIGHT;
            singleButton_Center.ButtonText = GlobalMessages.BALANCE;
        }

        private void HSlider_Pan_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_rChannelPan = (float)(((double)fPercent - 0.5) * 2.0);
            label_Value.Text = m_rChannelPan.ToString("F01");
        }

        private void SingleButton_Center_ButtonClickNotify(SingleButton objSender)
        {
            m_rChannelPan = 0.0f;
            hSlider_Pan.Position = 50U;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmChannelPan));
            label_Left = new Label();
            label_Right = new Label();
            hSlider_Pan = new HSlider();
            singleButton_Center = new SingleButton();
            label_Value = new Label();
            SuspendLayout();
            label_Left.AutoSize = true;
            label_Left.Location = new Point(48, 9);
            label_Left.Name = "label_Left";
            label_Left.Size = new Size(35, 12);
            label_Left.TabIndex = 0;
            label_Left.Text = "$LEFT";
            label_Right.AutoSize = true;
            label_Right.Location = new Point(386, 9);
            label_Right.Name = "label_Right";
            label_Right.Size = new Size(41, 12);
            label_Right.TabIndex = 1;
            label_Right.Text = "$RIGHT";
            hSlider_Pan.BackColor = SystemColors.Control;
            hSlider_Pan.Location = new Point(24, 29);
            hSlider_Pan.MoveDelta = 1U;
            hSlider_Pan.Name = "hSlider_Pan";
            hSlider_Pan.Position = 50U;
            hSlider_Pan.PositionFloat = 0.5f;
            hSlider_Pan.Size = new Size(403, 47);
            hSlider_Pan.TabIndex = 2;
            hSlider_Pan.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(HSlider_Pan_PositionChangeNotify);
            singleButton_Center.BackColor = SystemColors.Control;
            singleButton_Center.ButtonText = "$BALANCE";
            singleButton_Center.Location = new Point(172, 84);
            singleButton_Center.Name = "singleButton_Center";
            singleButton_Center.Size = new Size(112, 40);
            singleButton_Center.TabIndex = 3;
            singleButton_Center.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_Center_ButtonClickNotify);
            label_Value.Location = new Point(170, 9);
            label_Value.Name = "label_Value";
            label_Value.Size = new Size(114, 17);
            label_Value.TabIndex = 4;
            label_Value.Text = "0.0";
            label_Value.TextAlign = ContentAlignment.TopCenter;
            AutoScaleDimensions = new SizeF(6f, 12f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(456, 140);
            Controls.Add(label_Value);
            Controls.Add(singleButton_Center);
            Controls.Add(hSlider_Pan);
            Controls.Add(label_Right);
            Controls.Add(label_Left);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = nameof(FrmChannelPan);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "$CHANNEL_PAN";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
