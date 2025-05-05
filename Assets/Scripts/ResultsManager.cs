using UnityEngine;
using TMPro;

public class ResultsManager : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI maxScoreText;
    public TextMeshProUGUI minScoreText;

    public PlayerDataSO playerData;
    public ScoreRecordSO scoreRecord;

    [SerializeField] private NotificationManager notificationManager;

    void Start()
    {
        float finalScore = playerData.currentScore;

        // Actualizar puntajes
        bool isNewMaxScore = finalScore > scoreRecord.maxScore;
        scoreRecord.UpdateScores(finalScore);

        // Mostrar puntajes en la UI
        finalScoreText.text = "Final Score: " + Mathf.FloorToInt(finalScore).ToString();
        maxScoreText.text = "Max Score: " + Mathf.FloorToInt(scoreRecord.maxScore).ToString();
        minScoreText.text = "Min Score: " + Mathf.FloorToInt(scoreRecord.minScore).ToString();

        // Enviar notificaciones
        SendNotifications(finalScore, isNewMaxScore);
    }

    private void SendNotifications(float finalScore, bool isNewMaxScore)
    {
        // Notificación 1: Ronda Terminada
        notificationManager.SendNotification(
            "Ronda Terminada",
            $"Puntaje conseguido: {Mathf.FloorToInt(finalScore)}",
            "icon_round_end", // Cambia esto por el nombre del ícono en tu proyecto
            1
        );

        // Notificación 2: Nuevo Puntaje Máximo
        if (isNewMaxScore)
        {
            notificationManager.SendNotification(
                "Nuevo Puntaje Máximo",
                $"¡Felicidades! Nuevo puntaje máximo: {Mathf.FloorToInt(finalScore)}",
                "icon_new_highscore", // Cambia esto por el nombre del ícono en tu proyecto
                2
            );
        }
    }
}