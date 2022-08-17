using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionFormController : MonoBehaviour
{
    [Header("Include Settings")]
    [SerializeField]
    private TMP_InputField partnerKey;
    [SerializeField]
    private TMP_Dropdown envorimentLevel;
    [SerializeField]
    private TMP_InputField clue;
    [SerializeField]
    private TMP_InputField question;
    [SerializeField]
    private TMP_InputField anwser1;
    [SerializeField]
    private TMP_InputField anwser2;
    [SerializeField]
    private TMP_InputField anwser3;
    [SerializeField]
    private TMP_InputField anwser4;

    [Header("View Settings")]
    [SerializeField]
    private TMP_InputField envorimentLevelView;
    [SerializeField]
    private TMP_InputField clueView;
    [SerializeField]
    private TMP_InputField questionView;
    [SerializeField]
    private TMP_InputField anwser1View;
    [SerializeField]
    private TMP_InputField anwser2View;
    [SerializeField]
    private TMP_InputField anwser3View;
    [SerializeField]
    private TMP_InputField anwser4View;

    [Header("Edit Settings")]
    [SerializeField]
    private TMP_Dropdown envorimentLevelEdit;
    [SerializeField]
    private TMP_InputField clueEdit;
    [SerializeField]
    private TMP_InputField questionEdit;
    [SerializeField]
    private TMP_InputField anwser1Edit;
    [SerializeField]
    private TMP_InputField anwser2Edit;
    [SerializeField]
    private TMP_InputField anwser3Edit;
    [SerializeField]
    private TMP_InputField anwser4Edit;
    [SerializeField]
    private Button saveEditBtn;


    [SerializeField]
    private GameObject ownQuestionsScroll;
    [SerializeField]
    private GameObject otherQuestionsScroll;

    [SerializeField]
    private GameObject ownQuestionContent;
    [SerializeField]
    private GameObject otherQuestionContent;

    [SerializeField]
    private Button deleteButton;

    private float xOffset = -8.539f;
    private float yOffset = 135f;

    MainMenuController mmController;

    private void Start()
    {
        mmController = FindObjectOfType<MainMenuController>();
    }

    public void saveQuestion()
    {
        if (validateForm())
        {
            QuestionObject question = new QuestionObject(
                    index: QuestionController.sumIndex(),
                    partnerKey: this.partnerKey.text,
                    environmentLevel: this.envorimentLevel.value,
                    clue: this.clue.text,
                    question: this.question.text,
                    answer1: this.anwser1.text,
                    answer2: this.anwser2.text,
                    answer3: this.anwser3.text,
                    answer4: this.anwser4.text
                );
            
            QuestionController.questions.Add(question);
            JsonFileHandler.saveFile<QuestionObject>(QuestionController.questions);
        }     
    }

    public bool validateForm()
    {
        return true;
    }

    private void resetForm()
    {
        clue.text = "";
        question.text = "";
        anwser1.text = "";
        anwser2.text = "";
        anwser3.text = "";
        anwser4.text = "";
    }

    public void addOwnQuestionCard(string cardText, int questionIndex, float yPosition)
    {
        GameObject card = Instantiate(ownQuestionContent, ownQuestionsScroll.transform);

        foreach(Button button in (card.GetComponentsInChildren<Button>()))
        {
            if(button.gameObject.name.Equals("Edit"))
                button.onClick.AddListener(delegate { editButtonEvent(questionIndex); });
            else
                button.onClick.AddListener(delegate { deleteButtonEvent(questionIndex); });
        }

        RectTransform cardPos = card.GetComponent<RectTransform>();
        TMP_Text textCard = card.GetComponentInChildren<TMP_Text>();
        cardPos.anchoredPosition = new Vector2(xOffset, yPosition);
        textCard.text = cardText;
    }

    public void addOtherQuestionCard(string cardText,int questionIndex, float yPosition)
    {
        GameObject card = Instantiate(otherQuestionContent, otherQuestionsScroll.transform);

        foreach (Button button in (card.GetComponentsInChildren<Button>()))
        {
            if (button.gameObject.name.Equals("View"))
                button.onClick.AddListener(delegate { viewButtonEvent(questionIndex); });
        }

        RectTransform cardPos = card.GetComponent<RectTransform>();
        TMP_Text textCard = card.GetComponentInChildren<TMP_Text>();
        cardPos.anchoredPosition = new Vector2(xOffset, yPosition);
        textCard.text = cardText;
    }

    public void cleanScrolls()
    {
        resetForm();
        foreach (Transform child in ownQuestionsScroll.GetComponentInChildren<Transform>())
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in otherQuestionsScroll.GetComponentInChildren<Transform>())
        {
            Destroy(child.gameObject);
        }
    }

    public void loadQuestions()
    {
        cleanScrolls();
        QuestionController.separeRegistredQuestions(partnerKey.text);

        float currentY = -64.132f;

        foreach (QuestionObject question in QuestionController.ownQuestions)
        {
            addOwnQuestionCard(question.question, question.index, currentY);
            currentY -= yOffset;
        }

        currentY = -64.132f;

        foreach (QuestionObject question in QuestionController.othersQuestions)
        {
            addOtherQuestionCard(question.question, question.index, currentY);
            currentY -= yOffset;
        }
    }

    private void editButtonEvent(int index)
    {
        foreach(QuestionObject question in QuestionController.questions){
            if (question.index == index){
                setEditForm(question);
                saveEditBtn.onClick.RemoveAllListeners();
                saveEditBtn.onClick.AddListener(delegate { editQuestion(question); } );
                break;
            }
        }
        mmController.openEditPanel();
    }

    public void editQuestion(QuestionObject question){
       QuestionObject editedQuestion = new QuestionObject();
       editedQuestion.index = question.index;
       editedQuestion.partnerKey = question.partnerKey;
       editedQuestion.environmentLevel = envorimentLevelEdit.value;
       editedQuestion.question = questionEdit.text;
       editedQuestion.clue = clueEdit.text;
       editedQuestion.answer1 = anwser1Edit.text;
       editedQuestion.answer2 = anwser2Edit.text;
       editedQuestion.answer3 = anwser3Edit.text;
       editedQuestion.answer4 = anwser4Edit.text;

       int indexForeach = 0;
       foreach(QuestionObject questionObj in QuestionController.questions){
            if (questionObj.index == question.index){
                QuestionController.editQuestion(indexForeach, editedQuestion);
                break;
            }
            indexForeach++;
        }
        loadQuestions();
    }

    private void deleteButtonEvent(int index)
    {
        deleteButton.onClick.RemoveAllListeners();
        deleteButton.onClick.AddListener(delegate { deleteQuestion(index); });
        mmController.openDeleteAnwserPanel();      
    }

    private void viewButtonEvent(int index)
    {
        foreach(QuestionObject question in QuestionController.questions){
            if (question.index == index){
                setViewForm(question);
                break;
            }
        }

        mmController.openViewList();
    }


    private void setViewForm(QuestionObject question){
        envorimentLevelView.text = envorimentLevelToString(question.environmentLevel);
        clueView.text = question.clue;
        questionView.text = question.question;
        anwser1View.text = question.answer1;
        anwser2View.text = question.answer2;
        anwser3View.text = question.answer3;
        anwser4View.text = question.answer4;
    }
    private void setEditForm(QuestionObject question){
        envorimentLevelEdit.value = question.environmentLevel;
        clueEdit.text = question.clue;
        questionEdit.text = question.question;
        anwser1Edit.text = question.answer1;
        anwser2Edit.text = question.answer2;
        anwser3Edit.text = question.answer3;
        anwser4Edit.text = question.answer4;
    }
    public void deleteQuestion(int index)
    {
        int questionIndex = 0;
        foreach (QuestionObject question in QuestionController.questions)
        {
            if (question.index == index){
                break;
            }
            
            questionIndex++;
        }
        QuestionController.removeQuestion(questionIndex);
        loadQuestions();
    }

    public string envorimentLevelToString(int envorimentLevel){
        switch(envorimentLevel){
            case 0:
                return "Básico";
            case 1:
               return "Intermediário"; 
            case 2:
                return "Avançado";
            default:
                return "Não Reconhecido";
        }
    }
}
