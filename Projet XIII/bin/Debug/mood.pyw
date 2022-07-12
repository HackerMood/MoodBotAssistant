from email.mime import audio
from re import T
import speech_recognition as sr

r = sr.Recognizer()


while(1):
    
    with sr.Microphone() as source:
        print("Speak : ")
        audio = r.listen(source,None,3)
        try:
            text = r.recognize_google(audio, language='fr-FR')
            print("You said this: {}".format(text))
            with open('command.txt', 'w') as f:
                f.write(text)
        except:
            print("Sorry could n...")
