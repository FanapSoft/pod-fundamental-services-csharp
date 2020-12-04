using POD_AI.Base;
public class ImageProcessingAuthenticationContentSrv {

    public string Confidence { get; set; }

    private string resultStatus;
    public string ResultStatus
    {
        get => resultStatus;
        set
        {
            resultStatus = value;
            SetStatusMessage();
        }
        
    }
    public string StatusMessage { get; set; }
  
    public void SetStatusMessage()
    {
        switch (resultStatus)
        {
            case "-1":
                StatusMessage = StatuseMessageConst.NO_FACE_IN_FIRST_IMAGE;
                break;
            case "-2":
                StatusMessage = StatuseMessageConst.NO_FACE_IN_SECOND_IMAGE;
                break;
            case "1":
                StatusMessage = StatuseMessageConst.PROBABLY_MATCH;
                break;
            case "2":
                StatusMessage = StatuseMessageConst.PROBABLY_MISSMATCH;
                break;
            case "0":
                StatusMessage = StatuseMessageConst.MATCH;
                break;
            case "3":
                StatusMessage = StatuseMessageConst.MISMATCH;
                break;
        }
    }
}
