using System.Drawing;
using Gamepage_Classlibrary;
using Gamepage_DAL;

namespace Gamepage_Winforms
{
    public partial class Gamepage : Form
    {
        Gamecontainer gcon = new Gamecontainer(new GameSQLDAL());
        Clipcontainer ccon = new Clipcontainer(new ClipSQLDAL());
        Commentcontainer cocon = new Commentcontainer(new CommentDAL());

        public Gamepage()
        {
            InitializeComponent();
            DataSourceMethodGame();
            checkGameListbox();
        }

        private void checkGameListbox()
        {
            if (gameListBox.Items.Count > 0)
            {
                gameListBox.Show();
            }
            else
            {
                gameListBox.Hide();
            }
        }

        private void DataSourceMethodGame()
        {
            gameListBox.DataSource = gcon.getGameList();
        }

        private void DataSourceMethodCLip(Clip dataclip)
        {
            clipListBox.DataSource = ccon.GetClipList(dataclip.GameID);
            clipListBox.DisplayMember = "Title";
        }

        private void DataSourceMethodComment(Comment datacomment)
        {
            commentListBox.DataSource = cocon.getCommentList(datacomment.ClipID);
            commentListBox.DisplayMember = "CommentText";
        }

        private void ShowCertainClips()
        {
            clipListBox.DataSource = null;

            Clip c = new();
            Game g = (Game)gameListBox.SelectedItem;

            c.GameID = g.ID;

            DataSourceMethodCLip(c);
        }

        private void ShowCertainComments()
        {
            commentListBox.DataSource = null;

            Comment co = new();
            Clip c = (Clip)clipListBox.SelectedItem;

            co.ClipID = c.ClipID;

            DataSourceMethodComment(co);
        }

        private void GameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gameListBox.SelectedIndex > -1)
            {
                clipsGroupBox.Show();
                ShowCertainClips();
            }
            else
            {
                clipsGroupBox.Hide();
            }
        }

        private void clipListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clipListBox.SelectedIndex > -1)
            {
                commentGroupBox.Show();
                ShowCertainComments();
            }
            else
            {
                commentGroupBox.Hide();
            }
        }

        private void GameSubmitButton_Click(object sender, EventArgs e)
        {
            Game g = new()
            {
                Name = nameGameTextBox.Text
            };

            gcon.AddGame(g);

            nameGameTextBox.Text = string.Empty;

            DataSourceMethodGame();

            checkGameListbox();
        }

        private void AddClipButton_Click(object sender, EventArgs e)
        {
            Clip c = new();
            Game g = (Game)gameListBox.SelectedItem;

            c.Title = titelClipTextBox.Text;
            c.GameID = g.ID;

            ccon.AddClip(c);

            titelClipTextBox.Text = string.Empty;
            
            DataSourceMethodCLip(c);
        }

        private void submitCommentButton_Click(object sender, EventArgs e)
        {
            Comment co = new();
            Clip c = (Clip)clipListBox.SelectedItem;

            co.CommentText = commentTextBox.Text;
            co.ClipID = c.ClipID;

            cocon.addComment(co);

            commentTextBox.Text = string.Empty;

            DataSourceMethodComment(co);
        }

        private void editGameButton_Click(object sender, EventArgs e)
        {
            Game g = new();
            g = (Game)gameListBox.SelectedItem;

            g.Name = nameGameTextBox.Text;

            gcon.updategame(g);

            nameGameTextBox.Text = string.Empty;

            DataSourceMethodGame();
        }

        private void deleteGameButton_Click(object sender, EventArgs e)
        {
            Game g = new();

            g = (Game)gameListBox.SelectedItem;

            gcon.removeGame(g);

            DataSourceMethodGame();
        }
    }
}