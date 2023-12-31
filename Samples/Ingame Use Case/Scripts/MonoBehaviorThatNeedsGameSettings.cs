namespace MadBox.Exercice
{
    using UnityEngine;

    public class MonoBehaviorThatNeedsGameSettings : MonoBehaviour
    {
        private bool isFetching = false;
        private bool success = false;
        private GUIContent statusLabelContent = new GUIContent();
        private GUIStyle statusLabelStyle = null;

        private void Start()
        {
            // Fetch the game settings.
            this.isFetching = true;
            Debug.Log($"Fetching the game's settings...");
            GameSettingsManager.GetManager().GetGameSettings(this.OnGetGameSettingsSuccess, this.OnGetGameSettingsError);
        }

        private void OnGetGameSettingsSuccess(GameSettings gameSettings)
        {
            this.isFetching = false;
            this.success = true;
            int entitiesCount = gameSettings.Entities.Length;
            for (int index = 0; index < entitiesCount; index++)
            {
                GameObject entity = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                entity.name = gameSettings.Entities[index].Name;
                entity.transform.position = Vector3.right * 1.25f * index;
                entity.GetComponent<Renderer>().material.color = Random.ColorHSV();
            }
             
            Debug.Log("Successfully fetched the game's settings.");
        }

        private void OnGetGameSettingsError(string error)
        {
            this.isFetching = false;
            this.success = false;
            GameObject entity = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            entity.GetComponent<Renderer>().material.color = Color.red;
            Debug.Log($"Error while fetching the game's settings; reason: {error}");
        }

        private void OnGUI()
        {
            if (this.statusLabelStyle == null)
            {
                this.statusLabelStyle = new GUIStyle(GUI.skin.label)
                {
                    fontSize = 24,
                    fontStyle = FontStyle.Bold,
                };
            }

            if (this.isFetching)
            {
                this.statusLabelContent.text = "Loading...";
            }
            else
            {
                this.statusLabelContent.text = this.success ? "Success" : "Error";
            }

            Rect statusLabelArea = GUILayoutUtility.GetRect(this.statusLabelContent, this.statusLabelStyle);
            GUI.Label(statusLabelArea, this.statusLabelContent, this.statusLabelStyle);
        }
    }
}
