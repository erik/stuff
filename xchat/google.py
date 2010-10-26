import json
import xchat
# why, Python, do you need two separate urllibs?
import urllib2
import urllib

__module_name__ = "google"
__module_version__ = "1.0"
__module_description__ = "Googles stuff"


# this command searches teh googles for information, then provides the first link

def google(query):
    apiurl = "http://ajax.googleapis.com/ajax/services/search/web?v=1.0&q="

    xchat.prnt(query)
    
    body = urllib2.urlopen(apiurl + urllib.quote(query))
    jsonobj = json.loads(body.read())
    
    try:
        # oh unicode, you so silly
        estRes = jsonobj["responseData"]["cursor"]["estimatedResultCount"].encode('utf-8')
        firstResURL = jsonobj["responseData"]["results"][0]["unescapedUrl"].encode('utf-8')
        firstResTitle = jsonobj["responseData"]["results"][0]["titleNoFormatting"].encode('utf-8')

        xchat.prnt("First result out of ~%s: \002%s\002 (%s)" % (estRes, firstResTitle, firstResURL))
        return
    except Exception:
        xchat.prnt("Uh oh, exception! D:")

    

def google_cmd(word, word_eol, userdata):

    if len(word) < 2:
        xchat.prnt("need a search query")
        return xchat.EAT_ALL

    google(word_eol[1])   
    
    return xchat.EAT_ALL

xchat.prnt("Google plugin loaded")
xchat.hook_command("google", google_cmd, help="/GOOGLE <search>")
