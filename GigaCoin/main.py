import datetime
import hashlib
from binascii import unhexlify, hexlify


class Block:
    def __init__(self, prev_hash, trans, amount):
        self.next = None
        self.__data = {
            "prev_hash": prev_hash,
            "trans": trans,
            "amount": amount,
            "hash now": "",
            "time now": datetime.datetime.now().time()
        }

        self.__data["hash"] = self.make_hash()

    def get_data(self):
        return self.__data

    def make_hash(self):
        test_hash = hexlify(hashlib.sha256(unhexlify(self.get_data()["prev_hash"])).digest()).decode("utf-8")
        print("Симуляция процесса майнинга \n")
        while test_hash[:3] != "000":
            test_hash = hexlify(hashlib.sha256(unhexlify(test_hash)).digest()).decode("utf-8")
            print(test_hash)
        return test_hash

    def append(self, trans, amount):
        n = self
        while n.next:
            n = n.next
        prev_hash = n.get_data()["hash"]
        end = Block(prev_hash, trans, amount)
        n.next = end


def print_block(block):
    node = block
    print(node.get_data())
    while node.next:
        node = node.next
        print(node.get_data())


def main():
    test_block = Block("0004a62d480d68f4b969f5650b8c24ef77967484a6deced71e36dbc494054555", 'Артём', 100)
    test_block.append("Никита", 1000)
    test_block.append("Давид", 42)
    print_block(test_block)


if __name__ == '__main__':
    main()
