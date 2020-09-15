class player():
    def __init__(self, pname, pcountry, pclub, pimg, ppos):
        self.pname=pname
        self.pcountry = pcountry
        self.pclub = pclub
        self.pimg = pimg
        self.ppos = ppos
    
    def txtform(self):
        return f'{self.pname}, {self.pcountry}, {self.pclub}, {self.pimg}, {self.ppos}'