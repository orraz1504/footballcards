class Rplayer():
    def __init__(self, rname, rRating):
        self.rname=rname
        self.rRating = rRating
    
    def txtform(self):
        return f'{self.rname}, {self.rRating}'