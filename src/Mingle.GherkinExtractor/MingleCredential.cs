using CredentialManagement;

namespace Mingle.GherkinExtractor
{
    public class MingleCredential : Credential
    {
        public MingleCredential()
        {
            Target = "Mingle";
            PersistanceType = PersistanceType.LocalComputer;

        }


        public bool Prompt()
        {
            var prompt = new VistaPrompt();
            prompt.Title = "Mingle Authentication";
            prompt.GenericCredentials = true;
            prompt.ShowSaveCheckBox = true;

            if (!string.IsNullOrEmpty(Username))
            {
                prompt.Username = Username;
            }

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                Username = prompt.Username;
                Password = prompt.Password;

                if (prompt.SaveChecked)
                {
                    Save();
                }

                return true;
            }

            return false;

        }
    }
}