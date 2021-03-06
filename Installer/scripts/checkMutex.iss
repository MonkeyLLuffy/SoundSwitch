[Code]
function PromptUntilProgramClosedOrInstallationCanceled(
              mutex: String ): Boolean;  
var
  ButtonPressed : Integer;
  UninstallMessage : String;
begin
  ButtonPressed := IDRETRY;
  UninstallMessage := mutex + ' is currently running. ' + #13 + #13 +
      'Please close it and then click on ''Retry'' to proceed with the uninstallation.';

  // Check if the program is running or if the user has pressed the cancel button
  while CheckForMutexes(mutex)  and ( ButtonPressed <> IDCANCEL ) do
  begin
    ButtonPressed := MsgBox( UninstallMessage , mbError, MB_RETRYCANCEL );    
  end;

  // Has the program been closed?
  Result := Not CheckForMutexes(mutex);
end;