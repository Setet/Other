import datetime
import hashlib
from binascii import unhexlify, hexlify


class Block:
    def __init__(self, prev_hash, trans, amount):
        current_date = datetime.datetime.now()
        dt = current_date.strftime("%d-%m-%Y %H:%M:%S")

        self.next = None
        self.__data = {
            "prev_hash": prev_hash,
            "trans": trans,
            "amount": amount,
            "hash": "",
            "time": dt
        }

        self.__data["hash"] = self.make_hash()

    def get_data(self):
        return self.__data

    def make_hash(self):
        test_hash = hexlify(hashlib.sha256(unhexlify(self.get_data()["prev_hash"])).digest()).decode("utf-8")
        while test_hash[:5] != "00000":
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
    first_hash = "000006c4e540ac98650aff319a600d87cb150b2b0c8d8b188f30fec7dc8b5ecf"
    test_block = Block(first_hash, 'Артём', 100)
    test_block.append("Никита", 128)
    test_block.append("Давид", 42)
    print_block(test_block)


if __name__ == '__main__':
    main()
