import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.applet.*;
import java.net.*;
import java.io.*;
import javax.sound.sampled.*;
import javax.swing.*;
import javax.swing.border.Border;
import javax.swing.border.LineBorder;
import javax.swing.filechooser.FileFilter;
import javax.swing.filechooser.FileNameExtensionFilter;


public class SoundMatrix extends JFrame implements Runnable,AdjustmentListener,ActionListener
{
    JToggleButton button[][] = new JToggleButton[37][180];
    JScrollPane buttonPane;
    JScrollBar tempoBar;
    JMenuBar menuBar;
    JMenu file, instrumentMenu, songsMenu, colMenu;
    JMenuItem save, load, addCol, remove;
    JMenuItem[] instrumentItems, prebuilts, colItems;
    JButton stopPlay, clear, randomChecks, split, colorMode;
    JFileChooser fileChooser;
    JLabel[] labels = new JLabel[button.length];
    JPanel buttonPanel, labelPanel, tempoPanel, menuButtonPanel;
    JLabel tempoLabel;
    boolean playing = true;
    boolean stop = true;
    JFrame frame = new JFrame();
    String[] clipNames;
    String initInstrument;
    Clip[] clip;
    int tempo;
    boolean isSplit = false;
    int colNum = 180, col=0;
    AudioInputStream audioIn;
    Font font = new Font("Times New Roman", Font.PLAIN,10);
    String[] instrumentNames ={"Bell", "Piano"};
    String[] prebuiltNames = {"River Flows In You", "Mario Theme", "Dragonborn"};
    File[] prebuiltPaths = {new File("/Users/Haha/Documents/Data Structures/river.txt"),new File("/Users/Haha/Documents/Data Structures/mario.txt"),new File("/Users/Haha/Documents/Data Structures/dragonborn.txt")};
    public SoundMatrix()
    {
        setSize(1000,800);
        clipNames = new String[]{"C0","B1","ASharp1","A1","GSharp1","G1","FSharp1","F1","E1","DSharp1","D1","CSharp1","C1","B2","ASharp2","A2","GSharp2","G2","FSharp2","F2","E2","DSharp2","D2","CSharp2","C2","B3","ASharp3","A3","GSharp3","G3","FSharp3","F3","E3","DSharp3","D3","CSharp3","C3"};
        clip = new Clip[clipNames.length];
        initInstrument = instrumentNames[0] + "/" + instrumentNames[0];
        try {
            for(int i = 0; i < clipNames.length; i++)
            {
                audioIn = AudioSystem.getAudioInputStream(new File("/Users/Haha/Documents/Data Structures/"+initInstrument+" - "+clipNames[i]+".wav"));
                clip[i] = AudioSystem.getClip();
                clip[i].open(audioIn);
            }
        } catch (UnsupportedAudioFileException e)
        {
            e.printStackTrace();
        } catch (IOException e)
        {
            e.printStackTrace();
        } catch (LineUnavailableException e)
        {
            e.printStackTrace();
        } catch(NullPointerException e)
        {
			e.printStackTrace();
        }
        buttonPanel = new JPanel();
        buttonPanel.setLayout(new GridLayout(button.length,button[0].length,2, 5));
        for (int x = 0; x < button.length; x++)
        {
            String name = clipNames[x].replaceAll("Sharp","#");
            for (int y = 0; y < button[0].length; y++)
            {
                button[x][y] = new JToggleButton();
                button[x][y].setFont(font);
                button[x][y].setText(name);
                button[x][y].setPreferredSize(new Dimension(30,30));
                button[x][y].setMargin(new Insets(0,0,0,0));
                buttonPanel.add(button[x][y]);
            }
        }
        tempoBar = new JScrollBar(JScrollBar.HORIZONTAL,200,0,50,500);
        tempoBar.addAdjustmentListener(this);
        tempo = tempoBar.getValue();
        tempoLabel = new JLabel("Tempo: " + tempo);
        tempoPanel = new JPanel(new BorderLayout());
        tempoPanel.add(tempoLabel, BorderLayout.WEST);
        tempoPanel.add(tempoBar, BorderLayout.CENTER);
        String currDir = System.getProperty("user.dir");
        //System.out.println(currDir);
        fileChooser = new JFileChooser(currDir);
        menuBar = new JMenuBar();
        menuBar.setLayout(new GridLayout(1,2));
        file = new JMenu("File");
        save = new JMenuItem("Save");
        load = new JMenuItem("Load");
        file.add(save);
        file.add(load);
        save.addActionListener(this);
        load.addActionListener(this);
        instrumentMenu = new JMenu("Instruments");
        instrumentItems = new JMenuItem[instrumentNames.length];
        for (int i = 0; i < instrumentNames.length; i++)
        {
            instrumentItems[i] = new JMenuItem(instrumentNames[i]);
            instrumentItems[i].addActionListener(this);
            instrumentMenu.add(instrumentItems[i]);
        }
        songsMenu = new JMenu("Prebuilt Songs");
        prebuilts = new JMenuItem[prebuiltNames.length];
        for(int i = 0; i < prebuiltNames.length; i++)
        {
            prebuilts[i] = new JMenuItem(prebuiltNames[i]);
            prebuilts[i].addActionListener(this);
            songsMenu.add(prebuilts[i]);
        }
        colMenu = new JMenu("Columns");
        addCol = new JMenuItem("Add");
        remove = new JMenuItem("Remove");
        colMenu.add(addCol);
        colMenu.add(remove);
        addCol.addActionListener(this);
        remove.addActionListener(this);
        menuBar.add(file);
        menuBar.add(instrumentMenu);
        menuBar.add(songsMenu);
        menuBar.add(colMenu);
        menuButtonPanel = new JPanel();
        menuButtonPanel.setLayout(new GridLayout(1, 5));
        colorMode = new JButton("Night Mode");
        colorMode.addActionListener(this);
        menuButtonPanel.add(colorMode);
        split = new JButton("Split");
        split.addActionListener(this);
        menuButtonPanel.add(split);
        randomChecks = new JButton("Rand");
        randomChecks.addActionListener(this);
        menuButtonPanel.add(randomChecks);
        stopPlay = new JButton("Play");
        stopPlay.addActionListener(this);
        menuButtonPanel.add(stopPlay);
        clear = new JButton("Clear");
        clear.addActionListener(this);
        menuButtonPanel.add(clear);
        menuBar.add(menuButtonPanel,BorderLayout.EAST);
        buttonPane = new JScrollPane(buttonPanel,JScrollPane.VERTICAL_SCROLLBAR_ALWAYS, JScrollPane.HORIZONTAL_SCROLLBAR_ALWAYS);
        this.add(buttonPane,BorderLayout.CENTER);
        this.add(tempoPanel,BorderLayout.SOUTH);
        this.add(menuBar,BorderLayout.NORTH);
        setVisible(true);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        Thread timing = new Thread(this);
        timing.start();
    }
    public void run()
    {
        do
        {
            try
            {
               if(stop)
                   new Thread().sleep(0);
               else{

                   for (int x = 0; x < button.length; x++){
                       if(button[x][col].isSelected())
                       {
                           clip[x].start();
                           button[x][col].setForeground(Color.YELLOW);
                       }
                   }
                   new Thread().sleep(500 - tempo);
                   for(int x = 0; x < button.length; x++)
                   {
                       if (button[x][col].isSelected()){
                           clip[x].stop();
                           clip[x].setFramePosition(0);
                           button[x][col].setForeground(Color.BLACK);
                       }
                   }
                   col++;
                   if(col==button[0].length)
                       col=0;
               }
            }
            catch(InterruptedException e)
            {
                e.printStackTrace();
            }
        } while(playing);
    }
    public void adjustmentValueChanged(AdjustmentEvent e)
    {
        tempo = tempoBar.getValue();
        tempoLabel.setText("Tempo: "+tempo);
    }
    public void actionPerformed(ActionEvent e)
    {

        if(e.getSource() == stopPlay)
        {
            stop = !stop;
            if(stop)
                stopPlay.setText("Play");
            else stopPlay.setText("Stop");
        }
        if(e.getSource() == randomChecks)
        {
            buttonPane.remove(buttonPanel);
            buttonPanel = new JPanel();
            button=new JToggleButton[37][colNum];
            buttonPanel.setLayout(new GridLayout(button.length,button[0].length));
            for(int x = 0; x < button.length; x++)
            {
                String name = clipNames[x].replaceAll("Sharp","#");
                for(int y = 0; y < button[0].length; y++)
                {
                    button[x][y] = new JToggleButton();
                    button[x][y].setFont(font);
                    button[x][y].setText(name);
                    if(x > 19 && isSplit)
                        button[x][y].setForeground(Color.CYAN);
                    else
                        button[x][y].setForeground(Color.BLACK);
                    button[x][y].setPreferredSize(new Dimension(30,30));
                    button[x][y].setMargin(new Insets(0,0,0,0));
                    buttonPanel.add(button[x][y]);
                }
            }
            this.remove(buttonPane);
            buttonPane = new JScrollPane(buttonPanel,JScrollPane.VERTICAL_SCROLLBAR_ALWAYS, JScrollPane.HORIZONTAL_SCROLLBAR_ALWAYS);
            this.add(buttonPane,BorderLayout.CENTER);
            for(int y = 0; y < button[0].length; y++)
            {
                for(int x = 0; x < (int)(Math.random()*4); x++)
                {
                    try
                    {
                    	button[(int)(Math.random()*button.length)][y].setSelected(true);
                    }
                    catch(NullPointerException ex)
                    {
						ex.printStackTrace();
					}
                    catch(ArrayIndexOutOfBoundsException ex)
                    {
						ex.printStackTrace();
					}
                }
            }
            this.revalidate();
        }
        if(e.getSource() == addCol)
        {
            colNum++;
            buttonPane.remove(buttonPanel);
            buttonPanel = new JPanel();
            button=new JToggleButton[37][colNum];
            buttonPanel.setLayout(new GridLayout(button.length,button[0].length));
            for(int x = 0; x < button.length; x++){
                String name = clipNames[x].replaceAll("Sharp","#");
                for(int y = 0; y < button[0].length; y++)
                {
                    button[x][y] = new JToggleButton();
                    button[x][y].setFont(font);
                    button[x][y].setText(name);
                    if(x > 19 && isSplit)
                        button[x][y].setForeground(Color.CYAN);
                    else
                        button[x][y].setForeground(Color.BLACK);
                    button[x][y].setPreferredSize(new Dimension(30,30));
                    button[x][y].setMargin(new Insets(0,0,0,0));
                    buttonPanel.add(button[x][y]);
                }
            }
            this.remove(buttonPane);
            buttonPane = new JScrollPane(buttonPanel, JScrollPane.VERTICAL_SCROLLBAR_ALWAYS, JScrollPane.HORIZONTAL_SCROLLBAR_ALWAYS);
            this.add(buttonPane,BorderLayout.CENTER);
            col=0;
            stop = true;
            stopPlay.setText("Play");
            this.revalidate();
        }
    	if(e.getSource() == remove)
    	{
            colNum--;
            buttonPane.remove(buttonPanel);
            buttonPanel = new JPanel();
            button=new JToggleButton[37][colNum];
            buttonPanel.setLayout(new GridLayout(button.length,button[0].length));
            for(int x = 0; x < button.length; x++)
            {
                String name = clipNames[x].replaceAll("Sharp","#");
                for(int y = 0; y < button[0].length; y++)
                {
                    button[x][y] = new JToggleButton();
                    button[x][y].setFont(font);
                    button[x][y].setText(name);
                    if(x > 19 && isSplit)
                        button[x][y].setForeground(Color.CYAN);
                    else
                        button[x][y].setForeground(Color.BLACK);
                    button[x][y].setPreferredSize(new Dimension(30,30));
                    button[x][y].setMargin(new Insets(0,0,0,0));
                    buttonPanel.add(button[x][y]);
                }
            }
            this.remove(buttonPane);
            buttonPane = new JScrollPane(buttonPanel, JScrollPane.VERTICAL_SCROLLBAR_ALWAYS, JScrollPane.HORIZONTAL_SCROLLBAR_ALWAYS);
            this.add(buttonPane,BorderLayout.CENTER);
            col = 0;
            stop = true;
            stopPlay.setText("Play");
            this.revalidate();
        }
        if(e.getSource() == load)
        {
            int returnVal = fileChooser.showOpenDialog(this);
            if(returnVal==JFileChooser.APPROVE_OPTION)
            {
                try
                {
                    File loadFile = fileChooser.getSelectedFile();
                    BufferedReader input = new BufferedReader(new FileReader(loadFile));
                    String temp;
                    temp = input.readLine();
                    tempo = Integer.parseInt(temp.substring(0,3));
                    tempoBar.setValue(tempo);
                    Character[][] song = new Character[button.length][temp.length() - 2];
                    int x = 0;
                    while((temp=input.readLine())!=null)
                    {
                        for(int y = 2; y <song[0].length; y++)
                            song[x][y - 2] = temp.charAt(y);
                        x++;
                    }
                    setNotes(song);
                }catch(IOException ex)
                {
					ex.printStackTrace();
				}
                col=0;
                stop = true;
                stopPlay.setText("Play");
            }
        }
        if(e.getSource() == save)
        {
            saveSong();
        }
        if(e.getSource() == split)
        {
            this.isSplit = !this.isSplit;
            buttonPane.remove(buttonPanel);
            buttonPanel = new JPanel();
            button=new JToggleButton[37][colNum];
            buttonPanel.setLayout(new GridLayout(button.length, button[0].length));
            for(int x = 0; x < button.length; x++)
            {
                String name = clipNames[x].replaceAll("Sharp","#");
                for(int y = 0; y < button[0].length; y++)
                {
                    button[x][y] = new JToggleButton();
                    button[x][y].setFont(font);
                    button[x][y].setText(name);
                    if(x > 19 && isSplit)
                        button[x][y].setForeground(Color.CYAN);
                    else
                        button[x][y].setForeground(Color.BLACK);
                    button[x][y].setPreferredSize(new Dimension(30,30));
                    button[x][y].setMargin(new Insets(0,0,0,0));
                    buttonPanel.add(button[x][y]);
                }
            }
            this.remove(buttonPane);
            buttonPane = new JScrollPane(buttonPanel, JScrollPane.VERTICAL_SCROLLBAR_ALWAYS, JScrollPane.HORIZONTAL_SCROLLBAR_ALWAYS);
            this.add(buttonPane,BorderLayout.CENTER);
            try
            {
                for(int x = 0; x < clipNames.length; x++)
                {
                    audioIn = AudioSystem.getAudioInputStream(new File("/Users/Haha/Documents/Data Structures/"+initInstrument+" - "+clipNames[x]+".wav"));
                    clip[x] = AudioSystem.getClip();
                    clip[x].open(audioIn);
                }
            }
            catch(UnsupportedAudioFileException ex)
            {
                ex.printStackTrace();
            }
            catch(IOException ex)
            {
                ex.printStackTrace();
            }
            catch (LineUnavailableException ex)
            {
                ex.printStackTrace();
            }
            catch(NullPointerException ex)
            {
				ex.printStackTrace();
            }
            col=0;
            stop = true;
            stopPlay.setText("Play");
            this.revalidate();
        }
        if(e.getSource() == colorMode)
        {
			button[0][0].setBackground(Color.BLACK);
			if(colorMode.getText() == "Night Mode")
			{
				buttonPanel.setBackground(Color.BLACK);
				for(int i = 0; i < button.length; i++)
				{
					for (int j = 0; j < button[0].length; j++)
						button[i][j].setBackground(Color.GRAY);
				}
				colorMode.setText("Day Mode");
			}
			else
			{
				//System.out.println(colorMode.getText());
				buttonPanel.setBackground(Color.WHITE);
				for(int i = 0; i < button.length; i++)
				{
					for (int j = 0; j < button[0].length; j++)
						button[i][j].setBackground(Color.WHITE);
				}
				colorMode.setText("Night Mode");
			}
		}
        for(int i = 0; i < prebuiltNames.length; i++)
        {
            if(e.getSource() == prebuilts[i])
            {
                try
                {
                    File prebuiltFile = prebuiltPaths[i];
                    BufferedReader input = new BufferedReader(new FileReader(prebuiltFile));
                    String temp;
                    temp = input.readLine();
                    tempo = Integer.parseInt(temp.substring(0,3));
                    tempoBar.setValue(tempo);
                    Character[][] song = new Character[button.length][temp.length() - 2];
                    int x = 0;
                    while((temp = input.readLine()) != null)
                    {
                        for(int y = 2; y < song[0].length; y++)
                        {
                            song[x][y - 2] = temp.charAt(y);
                        }
                        x++;
                    }
                    setNotes(song);
                }
                catch(IOException ex)
                {
					ex.printStackTrace();
				}
                col=0;
                stop = true;
                stopPlay.setText("Play");
            }
        }
        for(int y = 0; y < instrumentItems.length; y++)
        {
            if(e.getSource() == instrumentItems[y])
            {
                String selectedInstrument = instrumentNames[y] + "/" + instrumentNames[y];
                try {
                    for(int x = 0; x < clipNames.length; x++)
                    {
    					audioIn = AudioSystem.getAudioInputStream(new File("/Users/Haha/Documents/Data Structures/" + selectedInstrument + " - " + clipNames[x]+".wav"));
                        clip[x] = AudioSystem.getClip();
                        clip[x].open(audioIn);
                    }

                }
                catch (UnsupportedAudioFileException ex)
                {
                    ex.printStackTrace();
                }
                catch (IOException ex)
                {
                    ex.printStackTrace();
                }
                catch (LineUnavailableException ex)
                {
                    ex.printStackTrace();
                }
                catch(NullPointerException ex)
                {
					ex.printStackTrace();
                }
                col = 0;
                stop = true;
                stopPlay.setText("Play");
            }
        }
        if(e.getSource() == clear)
        {
            for (int x = 0; x < button.length; x++)
            {
                for (int y = 0; y < button[0].length; y++)
                {
                    button[x][y].setSelected(false);
                    button[x][y].setForeground(Color.BLACK);
                    isSplit = false;
                }
            }
            col = 0;
            stop = true;
            stopPlay.setText("Play");
        }
    }
    public void setNotes(Character[][] notes)
    {
	    buttonPane.remove(buttonPanel);
		buttonPanel = new JPanel();
	    button=new JToggleButton[37][notes[0].length];
	    buttonPanel.setLayout(new GridLayout(button.length,button[0].length));
	    for(int x = 0; x < button.length; x++)
	    {
	    	String name = clipNames[x].replaceAll("Sharp","#");
	        for(int y = 0; y < button[0].length; y++)
	        {
	        	button[x][y] = new JToggleButton();
	            button[x][y].setFont(font);
	            button[x][y].setText(name);
	            if(x > 19 && isSplit)
	            	button[x][y].setForeground(Color.CYAN);
	            else
	                button[x][y].setForeground(Color.BLACK);
	            button[x][y].setPreferredSize(new Dimension(30,30));
	            button[x][y].setMargin(new Insets(0,0,0,0));
	            buttonPanel.add(button[x][y]);
	            }
	        }
	        this.remove(buttonPane);
	        buttonPane = new JScrollPane(buttonPanel,JScrollPane.VERTICAL_SCROLLBAR_ALWAYS,JScrollPane.HORIZONTAL_SCROLLBAR_ALWAYS);
	        this.add(buttonPane,BorderLayout.CENTER);
	        for(int x = 0; x < button.length; x++)
	        {
	        for(int y = 0; y < button[0].length; y++)
	        {
	        	try
	        	{
	            	if(notes[x][y]=='x')
	                	button[x][y].setSelected(true);
	                else button[x][y].setSelected(false);
	            }
	            catch(NullPointerException npe)
	            {
				}
	            catch(ArrayIndexOutOfBoundsException ex)
	            {
					ex.printStackTrace();
				}
	        }
		}
	    this.revalidate();
    }
    public void saveSong()
    {
        FileFilter filter = new FileNameExtensionFilter("*.txt","txt");
        fileChooser.setFileFilter(filter);
        if(fileChooser.showSaveDialog(null) == JFileChooser.APPROVE_OPTION)
        {
            File file = fileChooser.getSelectedFile();
            try
            {
                String st = file.getAbsolutePath();
                if(st.indexOf(".txt") >= 0)
                    st = st.substring(0, st.length()-4);
                String output = "";
                String [] noteNames = {" ","c ","b ","a-","a ","g-","g ","f-","f ","e ","d-","d ","c-","c ","b ","a-","a ","g-","g ","f-","f ","e ","d-","d ","c-","c ","b ","a-","a ","g-","g ","f-","f ","e ","d-","d ","c-","c "};
                for(int i = 0; i < button.length; i++)
                {
                    if(i == 0)
                    {
                        output += tempo;
                        for(int x = 0; x < button[0].length; x++)
                            output += " ";
                    }
                    else
                    {
                        output += noteNames[i];
                        for(int y = 0; y < button[0].length; y++)
                        {
                            if(button[i - 1][y].isSelected())
                                output += "x";
                            else output += "-";
                        }
                    }
                    output += "\n";
                }
                BufferedWriter outputStream = new BufferedWriter(new FileWriter(st + ".txt"));
                outputStream.write(output);
                outputStream.close();
            }
            catch(IOException ex)
            {
				ex.printStackTrace();
			}
        }
    }
    public static void main(String args[])
    {
        SoundMatrix app = new SoundMatrix();
    }
}